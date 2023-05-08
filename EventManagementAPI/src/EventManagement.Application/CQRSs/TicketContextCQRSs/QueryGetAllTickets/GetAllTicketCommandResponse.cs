using EventManagement.Application.ViewModels.TicketContextViewModels;

namespace EventManagement.Application.CQRSs.TicketContextCQRSs.QueryGetAllTickets
{
    public class GetAllTicketCommandResponse
    {
        public ICollection<TicketViewModel> Tickets { get; set; }

        public GetAllTicketCommandResponse(ICollection<TicketViewModel> tickets)
        {
            Tickets = tickets;
        }
    }
}
