using MediatR;
using System.ComponentModel.DataAnnotations;

namespace EventManagement.Application.CQRSs.UserContextCQRSs.CommandCreateUser
{
    public class CreateUserCommandRequest : IRequest<CreateUserCommandResponse>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        [StringLength(50, MinimumLength = 6)]
        public string Password { get; set; }

        public CreateUserCommandRequest(string name, string surname, string email, string password)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
        }
    }
}
