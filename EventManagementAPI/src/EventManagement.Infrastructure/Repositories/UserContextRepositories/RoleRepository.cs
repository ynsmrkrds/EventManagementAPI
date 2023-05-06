using EventManagement.Domain.Entities.UserContextEntities;
using EventManagement.Domain.Repositories.UserContextRepositories;
using EventManagement.Infrastructure.Context;

namespace EventManagement.Infrastructure.Repositories.UserContextRepositories
{
    public class RoleRepository : Repository<RoleEntity>, IRoleRepository
    {
        public RoleRepository(EventManagementDBContext context) : base(context)
        {
        }
    }
}
