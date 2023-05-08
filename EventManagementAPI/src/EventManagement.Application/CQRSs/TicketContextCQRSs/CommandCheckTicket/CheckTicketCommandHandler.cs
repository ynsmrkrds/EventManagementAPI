using EventManagement.Domain.Constants;
using EventManagement.Domain.Models;
using EventManagement.Domain.Repositories.TicketContextRepositories;
using MediatR;

namespace EventManagement.Application.CQRSs.TicketContextCQRSs.CommandCheckTicket
{
    public class CheckTicketCommandHandler : IRequestHandler<CheckTicketCommandRequest, CheckTicketCommandResponse>
    {
        private readonly ITicketRepository _ticketRepository;

        public CheckTicketCommandHandler(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public Task<CheckTicketCommandResponse> Handle(CheckTicketCommandRequest request, CancellationToken cancellationToken)
        {
            bool isValid = _ticketRepository.IsValid(request.TicketNo);

            ResponseConstant response = isValid ? ResponseConstants.TicketValid : ResponseConstants.TicketNotValid;

            return Task.FromResult(new CheckTicketCommandResponse(response));
        }
    }
}
