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
    }
}
