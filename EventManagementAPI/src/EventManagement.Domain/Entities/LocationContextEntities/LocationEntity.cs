using EventManagement.Domain.Entities.EventContextEntities;
using EventManagement.Domain.SeedWorks.BillingService.Domain.SeedWorks;
using System.ComponentModel.DataAnnotations;

namespace EventManagement.Domain.Entities.LocationContextEntities
{
    public class LocationEntity : BaseEntity
    {
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        public ICollection<EventEntity> Events { get; set; } = new List<EventEntity>();

        public LocationEntity(string name)
        {
            Name = name;
        }
    }
}
