using AutoMapper;
using EventManagement.Application.CQRSs.EventContextCQRSs.CommandUpdateEvent;
using EventManagement.Application.Helpers;
using EventManagement.Domain.Constants;
using EventManagement.Domain.Entities.EventContextEntities;
using EventManagement.Domain.Exceptions;
using EventManagement.Domain.Models;
using EventManagement.Domain.Repositories.EventContextRepositories;
using MediatR;

namespace EventManagement.Application.CQRSs.EventContextCQRSs.CommandCancelEvent
{
    public class CancelEventCommandHandler : IRequestHandler<CancelEventCommandRequest, CancelEventCommandResponse>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        private readonly int _remainingMinDayForUpdate = 5;

        public CancelEventCommandHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public Task<CancelEventCommandResponse> Handle(CancelEventCommandRequest request, CancellationToken cancellationToken)
        {
            TokenModel tokenModel = TokenHelper.Instance().DecodeTokenInRequest() ?? throw new ClientSideException(ExceptionConstants.TokenError);

            EventEntity eventEntity = _eventRepository.GetByID(request.EventID) ?? throw new ClientSideException(ExceptionConstants.NotFoundEvent);

            if (eventEntity.CreatedByID != tokenModel.UserID) return Task.FromResult(new CancelEventCommandResponse(ResponseConstants.UpdateFailed));

            if (DateTime.Now.AddDays(_remainingMinDayForUpdate) > eventEntity.Date) return Task.FromResult(new CancelEventCommandResponse(ResponseConstants.UpdateFailed));

            _mapper.Map(request, eventEntity);
            _eventRepository.Update(eventEntity);

            int effectedRows = _eventRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new CancelEventCommandResponse(ResponseConstants.UpdateFailed));

            return Task.FromResult(new CancelEventCommandResponse(ResponseConstants.SuccessfullyUpdated));
        }
    }
}
