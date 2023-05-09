using EventManagement.Domain.SeedWorks.BillingService.Domain.SeedWorks;
using System.ComponentModel.DataAnnotations;

namespace EventManagement.Domain.Entities.UserContextEntities
{
    public class RoleEntity : BaseEntity
    {
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [StringLength(255, MinimumLength = 10)]
        public string Description { get; set; }

        public ICollection<UserRoleEntity> UserRoles { get; set; } = new List<UserRoleEntity>();

        public RoleEntity(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
