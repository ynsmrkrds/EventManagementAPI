using MediatR;

namespace EventManagement.Application.CQRSs.TicketContextCQRSs.CommandCheckTicket
{
    public class CheckTicketCommandRequest : IRequest<CheckTicketCommandResponse>
    {
        public string TicketNo { get; set; }

        public CheckTicketCommandRequest(string ticketNo)
        {
            TicketNo = ticketNo;
        }
    }
}
