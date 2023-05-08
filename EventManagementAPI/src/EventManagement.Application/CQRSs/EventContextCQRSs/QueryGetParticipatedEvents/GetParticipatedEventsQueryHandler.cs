using AutoMapper;
using EventManagement.Application.CQRSs.EventContextCQRSs.QueryGetOrganizedEvents;
using EventManagement.Application.Helpers;
using EventManagement.Application.ViewModels.EventContextViewModels;
using EventManagement.Domain.Constants;
using EventManagement.Domain.Entities.EventContextEntities;
using EventManagement.Domain.Entities.TicketContextEntities;
using EventManagement.Domain.Exceptions;
using EventManagement.Domain.Models;
using EventManagement.Domain.Repositories.TicketContextRepositories;
using MediatR;

namespace EventManagement.Application.CQRSs.EventContextCQRSs.QueryGetParticipatedEvents
{
    public class GetParticipatedEventsQueryHandler : IRequestHandler<GetParticipatedEventsQueryRequest, GetParticipatedEventsQueryResponse>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;

        public GetParticipatedEventsQueryHandler(ITicketRepository ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }

        public Task<GetParticipatedEventsQueryResponse> Handle(GetParticipatedEventsQueryRequest request, CancellationToken cancellationToken)
        {
            TokenModel tokenModel = TokenHelper.Instance().DecodeTokenInRequest() ?? throw new ClientSideException(ExceptionConstants.TokenError);

            IQueryable<TicketEntity> tickets = _ticketRepository.GetAll(tokenModel.UserID);

            List<EventEntity> events = tickets.Where(x => x.Event != null).Select(x => x.Event!).ToList();

            List<EventViewModel> viewModels = _mapper.Map<List<EventEntity>, List<EventViewModel>>(events);

            return Task.FromResult(new GetParticipatedEventsQueryResponse(viewModels));
        }
    }
}
