using AutoMapper;
using EventManagement.Application.CQRSs.EventContextCQRSs.QueryGetAllEvents;
using EventManagement.Application.Helpers;
using EventManagement.Application.ViewModels.EventContextViewModels;
using EventManagement.Domain.Constants;
using EventManagement.Domain.Entities.EventContextEntities;
using EventManagement.Domain.Entities.TicketContextEntities;
using EventManagement.Domain.Exceptions;
using EventManagement.Domain.Models;
using EventManagement.Domain.Repositories.EventContextRepositories;
using EventManagement.Domain.Repositories.TicketContextRepositories;
using MediatR;

namespace EventManagement.Application.CQRSs.EventContextCQRSs.QueryGetOrganizedEvents
{
    public class GetOrganizedEventsQueryHandler : IRequestHandler<GetOrganizedEventsQueryRequest, GetOrganizedEventsQueryResponse>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public GetOrganizedEventsQueryHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public Task<GetOrganizedEventsQueryResponse> Handle(GetOrganizedEventsQueryRequest request, CancellationToken cancellationToken)
        {
            TokenModel tokenModel = TokenHelper.Instance().DecodeTokenInRequest() ?? throw new ClientSideException(ExceptionConstants.TokenError);

            List<EventEntity> eventEntities = _eventRepository.GetAll(tokenModel.UserID).ToList();

            List<EventViewModel> viewModels = _mapper.Map<List<EventEntity>, List<EventViewModel>>(eventEntities);

            return Task.FromResult(new GetOrganizedEventsQueryResponse(viewModels));
        }
    }
}
