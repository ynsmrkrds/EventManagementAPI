using EventManagement.Domain.Entities.UserContextEntities;
using EventManagement.Domain.Repositories.UserContextRepositories;
using EventManagement.Infrastructure.Context;

namespace EventManagement.Infrastructure.Repositories.UserContextRepositories
{
    public class UserRoleRepository : Repository<UserRoleEntity>, IUserRoleRepository
    {
        public UserRoleRepository(EventManagementDBContext context) : base(context)
        {
        }

        public UserRoleEntity? GetByRoleID(int roleID)
        {
            return _context.UserRoles
                .Where(x => x.RoleID == roleID)
                .FirstOrDefault();
        }

        public UserRoleEntity? GetByUserID(int userID)
        {
            return _context.UserRoles
                .Where(x => x.UserID == userID)
                .FirstOrDefault();
        }
    }
}
