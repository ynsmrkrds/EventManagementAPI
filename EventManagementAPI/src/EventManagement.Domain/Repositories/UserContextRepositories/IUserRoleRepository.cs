using EventManagement.Domain.Entities.UserContextEntities;

namespace EventManagement.Domain.Repositories.UserContextRepositories
{
    public interface IUserRoleRepository : IRepository<UserRoleEntity>
    {
        UserRoleEntity? GetByUserID(int userID);

        UserRoleEntity? GetByRoleID(int roleID);
    }
}
