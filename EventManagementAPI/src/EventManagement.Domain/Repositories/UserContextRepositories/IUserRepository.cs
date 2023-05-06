using EventManagement.Domain.Entities.UserContextEntities;

namespace EventManagement.Domain.Repositories.UserContextRepositories
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        bool IsExistsWithSameEmail(string email);

        UserEntity? ValidateUser(string email, string passwordHash);
    }
}
