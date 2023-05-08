using MediatR;

namespace EventManagement.Application.CQRSs.TicketContextCQRSs.CommandPurchaseTicket
{
    public class PurchaseTicketCommandRequest : IRequest<PurchaseTicketCommandResponse>
    {
        public int EventID { get; set; }

        public PurchaseTicketCommandRequest(int eventID)
        {
            EventID = eventID;
        }
    }
}
