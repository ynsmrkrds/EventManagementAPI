using EventManagement.Domain.SeedWorks;
using EventManagement.Domain.SeedWorks.BillingService.Domain.SeedWorks;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManagement.Domain.Entities.UserContextEntities
{
    public class UserRoleEntity : BaseEntity, IAggregateRoot
    {
        [ForeignKey(nameof(User))]
        public int UserID { get; set; }

        public UserEntity? User { get; set; }

        [ForeignKey(nameof(Role))]
        public int RoleID { get; set; }

        public RoleEntity? Role { get; set; }

        public UserRoleEntity(int userID, int roleID)
        {
            UserID = userID;
            RoleID = roleID;
        }
    }
}
