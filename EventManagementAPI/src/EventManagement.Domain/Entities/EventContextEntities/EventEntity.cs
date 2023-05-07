using EventManagement.Domain.Entities.CategoryContextEntities;
using EventManagement.Domain.Entities.LocationContextEntities;
using EventManagement.Domain.Entities.UserContextEntities;
using EventManagement.Domain.Enums.CategoryContextEnums;
using EventManagement.Domain.SeedWorks;
using EventManagement.Domain.SeedWorks.BillingService.Domain.SeedWorks;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManagement.Domain.Entities.EventContextEntities
{
    public class EventEntity : BaseEntity, IAggregateRoot
    {
        public string Title { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        [ForeignKey(nameof(Location))]
        public int LocationID { get; set; }

        public LocationEntity? Location { get; set; }

        public string Address { get; set; }

        public int Quota { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryID { get; set; }

        public CategoryEntity? Category { get; set; }

        [ForeignKey(nameof(CreatedBy))]
        public int CreatedByID { get; set; }

        public UserEntity? CreatedBy { get; set; }

        public EventStatus Status { get; set; }

        public EventEntity(string title, DateTime date, string description, int locationID, string address, int quota, int categoryID, int createdByID, EventStatus status)
        {
            Title = title;
            Date = date;
            Description = description;
            LocationID = locationID;
            Address = address;
            Quota = quota;
            CategoryID = categoryID;
            CreatedByID = createdByID;
            Status = status;
        }

        public static EventEntity Create(string title, DateTime date, string description, int locationID, string address, int quota, int categoryID)
        {
            return new EventEntity(title, date, description, locationID, address, quota, categoryID, -1, EventStatus.InReview);
        }
    }
}
