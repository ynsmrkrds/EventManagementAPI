using EventManagement.Domain.Entities.EventContextEntities;
using EventManagement.Domain.SeedWorks.BillingService.Domain.SeedWorks;

namespace EventManagement.Domain.Entities.CategoryContextEntities
{
    public class CategoryEntity : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<EventEntity> Events { get; set; } = new List<EventEntity>();

        public CategoryEntity(string name)
        {
            Name = name;
        }
    }
}
