using EventManagement.Domain.SeedWorks.BillingService.Domain.SeedWorks;

namespace EventManagement.Domain.Entities.CategoryContextEntities
{
    public class CategoryEntity : BaseEntity
    {
        public string Name { get; set; }

        public CategoryEntity(string name)
        {
            Name = name;
        }
    }
}
