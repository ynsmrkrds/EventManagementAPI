using EventManagement.Domain.Entities.EventContextEntities;
using EventManagement.Domain.SeedWorks.BillingService.Domain.SeedWorks;

namespace EventManagement.Domain.Entities.LocationContextEntities
{
    public class LocationEntity : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<EventEntity> Events { get; set; } = new List<EventEntity>();

        public LocationEntity(string name)
        {
            Name = name;
        }
    }
}
