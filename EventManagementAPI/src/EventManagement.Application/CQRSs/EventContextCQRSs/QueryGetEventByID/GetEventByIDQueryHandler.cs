using AutoMapper;
using EventManagement.Application.Helpers;
using EventManagement.Application.ViewModels.EventContextViewModels;
using EventManagement.Domain.Constants;
using EventManagement.Domain.Entities.EventContextEntities;
using EventManagement.Domain.Exceptions;
using EventManagement.Domain.Models;
using EventManagement.Domain.Repositories.EventContextRepositories;
using MediatR;

namespace EventManagement.Application.CQRSs.EventContextCQRSs.QueryGetEventByID
{
    public class GetEventByIDQueryHandler : IRequestHandler<GetEventByIDQueryRequest, GetEventByIDQueryResponse>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public GetEventByIDQueryHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public Task<GetEventByIDQueryResponse> Handle(GetEventByIDQueryRequest request, CancellationToken cancellationToken)
        {
            TokenModel tokenModel = TokenHelper.Instance().DecodeTokenInRequest() ?? throw new ClientSideException(ExceptionConstants.TokenError);

            EventEntity? eventEntity = _eventRepository.GetByID(request.EventID);
            if (eventEntity == null || tokenModel.UserID != eventEntity.CreatedByID) throw new ClientSideException(ExceptionConstants.NotFoundEvent);

            EventViewModel eventViewModel = _mapper.Map<EventViewModel>(eventEntity);

            return Task.FromResult(new GetEventByIDQueryResponse(eventViewModel));
        }
    }
}
