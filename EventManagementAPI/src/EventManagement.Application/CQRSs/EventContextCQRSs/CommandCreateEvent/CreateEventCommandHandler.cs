using AutoMapper;
using EventManagement.Application.Helpers;
using EventManagement.Domain.Constants;
using EventManagement.Domain.Entities.EventContextEntities;
using EventManagement.Domain.Exceptions;
using EventManagement.Domain.Models;
using EventManagement.Domain.Repositories.EventContextRepositories;
using MediatR;

namespace EventManagement.Application.CQRSs.EventContextCQRSs.CommandCreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommandRequest, CreateEventCommandResponse>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public CreateEventCommandHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public Task<CreateEventCommandResponse> Handle(CreateEventCommandRequest request, CancellationToken cancellationToken)
        {
            TokenModel tokenModel = TokenHelper.Instance().DecodeTokenInRequest() ?? throw new ClientSideException(ExceptionConstants.TokenError);

            EventEntity eventEntity = _mapper.Map<EventEntity>(request);
            eventEntity.CreatedByID = tokenModel.UserID;
            _eventRepository.Add(eventEntity);

            int effectedRows = _eventRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new CreateEventCommandResponse(ResponseConstants.CreateFailed));

            return Task.FromResult(new CreateEventCommandResponse(ResponseConstants.SuccessfullyCreated));
        }
    }
}
