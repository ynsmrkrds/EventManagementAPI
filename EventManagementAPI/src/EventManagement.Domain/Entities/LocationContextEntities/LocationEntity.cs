using EventManagement.Domain.SeedWorks.BillingService.Domain.SeedWorks;

namespace EventManagement.Domain.Entities.LocationContextEntities
{
    public class LocationEntity : BaseEntity
    {
        public string Name { get; set; }

        public LocationEntity(string name)
        {
            Name = name;
        }
    }
}
