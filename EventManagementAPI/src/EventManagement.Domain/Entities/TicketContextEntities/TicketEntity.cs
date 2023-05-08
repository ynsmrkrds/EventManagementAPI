using EventManagement.Domain.Entities.EventContextEntities;
using EventManagement.Domain.Entities.UserContextEntities;
using EventManagement.Domain.SeedWorks.BillingService.Domain.SeedWorks;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManagement.Domain.Entities.TicketContextEntities
{
    public class TicketEntity : BaseEntity
    {
        public string TicketNo { get; set; }

        [ForeignKey(nameof(Event))]
        public int EventID { get; set; }

        public EventEntity? Event { get; set; }

        public DateTime PurchaseDate { get; set; }

        [ForeignKey(nameof(PurchasedBy))]
        public int PurchasedByID { get; set; }

        public UserEntity? PurchasedBy { get; set; }

        public TicketEntity(string ticketNo, int eventID, DateTime purchaseDate, int purchasedByID)
        {
            TicketNo = ticketNo;
            EventID = eventID;
            PurchaseDate = purchaseDate;
            PurchasedByID = purchasedByID;
        }
    }
}
