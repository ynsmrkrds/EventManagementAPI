using EventManagement.Domain.SeedWorks.BillingService.Domain.SeedWorks;

namespace EventManagement.Domain.Entities.UserContextEntities
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public UserEntity(string name, string surname, string email, string passwordHash)
        {
            Name = name;
            Surname = surname;
            Email = email;
            PasswordHash = passwordHash;
        }
    }
}
