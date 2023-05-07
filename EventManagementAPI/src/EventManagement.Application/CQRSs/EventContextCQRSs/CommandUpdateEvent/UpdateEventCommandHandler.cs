using AutoMapper;
using EventManagement.Application.Helpers;
using EventManagement.Domain.Constants;
using EventManagement.Domain.Entities.EventContextEntities;
using EventManagement.Domain.Exceptions;
using EventManagement.Domain.Models;
using EventManagement.Domain.Repositories.EventContextRepositories;
using MediatR;

namespace EventManagement.Application.CQRSs.EventContextCQRSs.CommandUpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommandRequest, UpdateEventCommandResponse>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        private readonly int _remainingMinDayForUpdate = 5;

        public UpdateEventCommandHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public Task<UpdateEventCommandResponse> Handle(UpdateEventCommandRequest request, CancellationToken cancellationToken)
        {
            TokenModel tokenModel = TokenHelper.Instance().DecodeTokenInRequest() ?? throw new ClientSideException(ExceptionConstants.TokenError);

            EventEntity eventEntity = _eventRepository.GetByID(request.EventID) ?? throw new ClientSideException(ExceptionConstants.NotFoundEvent);

            if (eventEntity.CreatedByID != tokenModel.UserID) return Task.FromResult(new UpdateEventCommandResponse(ResponseConstants.UpdateFailed));

            if (DateTime.Now.AddDays(_remainingMinDayForUpdate) > eventEntity.Date) return Task.FromResult(new UpdateEventCommandResponse(ResponseConstants.UpdateFailed));

            _mapper.Map(request, eventEntity);
            _eventRepository.Update(eventEntity);

            int effectedRows = _eventRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new UpdateEventCommandResponse(ResponseConstants.UpdateFailed));

            return Task.FromResult(new UpdateEventCommandResponse(ResponseConstants.SuccessfullyUpdated));
        }
    }
}
