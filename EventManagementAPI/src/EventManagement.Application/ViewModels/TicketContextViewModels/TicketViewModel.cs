using EventManagement.Domain.Entities.EventContextEntities;
using EventManagement.Domain.Entities.UserContextEntities;

namespace EventManagement.Application.ViewModels.TicketContextViewModels
{
    public class TicketViewModel : BaseViewModel
    {
        public string TicketNo { get; set; }

        public EventEntity Event { get; set; }

        public DateTime PurchaseDate { get; set; }

        public UserEntity PurchasedBy { get; set; }

        public TicketViewModel(int id, DateTime createdDate, string ticketNo, EventEntity @event, DateTime purchaseDate, UserEntity purchasedBy) : base(id, createdDate)
        {
            TicketNo = ticketNo;
            Event = @event;
            PurchaseDate = purchaseDate;
            PurchasedBy = purchasedBy;
        }
    }
}
