using EventManagement.Application.DTOs.CQRSDTOs;
using EventManagement.Domain.Models;

namespace EventManagement.Application.CQRSs.UserContextCQRSs.CommandUpdateUser
{
    public class UpdateUserCommandResponse : BaseCommandResponseDTO
    {
        public UpdateUserCommandResponse(ResponseConstant response) : base(response)
        {
        }
    }
}
