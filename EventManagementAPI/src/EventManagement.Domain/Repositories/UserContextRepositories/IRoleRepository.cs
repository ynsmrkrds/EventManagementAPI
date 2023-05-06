using EventManagement.Domain.Entities.UserContextEntities;

namespace EventManagement.Domain.Repositories.UserContextRepositories
{
    public interface IRoleRepository : IRepository<RoleEntity>
    {
        RoleEntity? GetByName(string name);
    }
}
