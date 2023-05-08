using EventManagement.Domain.Entities.EventContextEntities;
using EventManagement.Domain.Entities.TicketContextEntities;
using EventManagement.Domain.SeedWorks.BillingService.Domain.SeedWorks;

namespace EventManagement.Domain.Entities.UserContextEntities
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public ICollection<EventEntity> Events { get; set; } = new List<EventEntity>();

        public ICollection<TicketEntity> Tickets { get; set; } = new List<TicketEntity>();

        public ICollection<UserRoleEntity> UserRoles { get; set; } = new List<UserRoleEntity>();

        public UserEntity(string name, string surname, string email, string passwordHash)
        {
            Name = name;
            Surname = surname;
            Email = email;
            PasswordHash = passwordHash;
        }
    }
}
