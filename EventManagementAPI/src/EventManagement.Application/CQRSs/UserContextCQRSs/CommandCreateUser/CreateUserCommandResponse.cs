using EventManagement.Application.DTOs.CQRSDTOs;
using EventManagement.Domain.Models;

namespace EventManagement.Application.CQRSs.UserContextCQRSs.CommandCreateUser
{
    public class CreateUserCommandResponse : BaseCommandResponseDTO
    {
        public CreateUserCommandResponse(ResponseConstant response) : base(response)
        {
        }
    }
}
