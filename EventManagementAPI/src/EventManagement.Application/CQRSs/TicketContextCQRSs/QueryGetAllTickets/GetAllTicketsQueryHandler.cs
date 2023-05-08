using AutoMapper;
using EventManagement.Application.CQRSs.CategoryContextCQRSs.QueryGetCategory;
using EventManagement.Application.Helpers;
using EventManagement.Application.ViewModels.TicketContextViewModels;
using EventManagement.Domain.Constants;
using EventManagement.Domain.Entities.TicketContextEntities;
using EventManagement.Domain.Exceptions;
using EventManagement.Domain.Models;
using EventManagement.Domain.Repositories.TicketContextRepositories;
using MediatR;

namespace EventManagement.Application.CQRSs.TicketContextCQRSs.QueryGetAllTickets
{
    public class GetAllTicketsQueryHandler : IRequestHandler<GetAllTicketCommandRequest, GetAllTicketCommandResponse>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;

        public GetAllTicketsQueryHandler(ITicketRepository ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }

        public Task<GetAllTicketCommandResponse> Handle(GetAllTicketCommandRequest request, CancellationToken cancellationToken)
        {
            TokenModel tokenModel = TokenHelper.Instance().DecodeTokenInRequest() ?? throw new ClientSideException(ExceptionConstants.TokenError);

            List<TicketEntity> ticketEntities = _ticketRepository.GetAll(tokenModel.UserID).ToList();

            List<TicketViewModel> viewModels = _mapper.Map<List<TicketViewModel>>(ticketEntities);

            return Task.FromResult(new GetAllTicketCommandResponse(viewModels));
        }
    }
}
