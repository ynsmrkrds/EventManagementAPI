using EventManagement.Domain.SeedWorks;
using EventManagement.Domain.SeedWorks.BillingService.Domain.SeedWorks;

namespace EventManagement.Domain.Entities.UserContextEntities
{
    public class UserRoleEntity : BaseEntity, IAggregateRoot
    {
        public int UserID { get; set; }

        public int RoleID { get; set; }

        public UserRoleEntity(int userID, int roleID)
        {
            UserID = userID;
            RoleID = roleID;
        }
    }
}
