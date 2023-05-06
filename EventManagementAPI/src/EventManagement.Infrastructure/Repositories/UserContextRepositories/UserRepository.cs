using EventManagement.Domain.Entities.UserContextEntities;
using EventManagement.Domain.Repositories.UserContextRepositories;
using EventManagement.Infrastructure.Context;

namespace EventManagement.Infrastructure.Repositories.UserContextRepositories
{
    public class UserRepository : Repository<UserEntity>, IUserRepository
    {
        public UserRepository(EventManagementDBContext context) : base(context)
        {
        }

        public bool IsExistsWithSameEmail(string email)
        {
            return _context.Users
                .Any(x => x.Email == email);
        }

        public UserEntity? ValidateUser(string email, string passwordHash)
        {
            return _context.Users.Where(x => x.Email == email && x.PasswordHash == passwordHash).FirstOrDefault();
        }
    }
}
