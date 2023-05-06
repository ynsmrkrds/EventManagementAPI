using EventManagement.Application.DTOs.CQRSDTOs;
using EventManagement.Domain.Models;

namespace EventManagement.Application.CQRSs.UserContextCQRSs.CommandUpdatePassword
{
    public class UpdatePasswordCommandResponse : BaseCommandResponseDTO
    {
        public UpdatePasswordCommandResponse(ResponseConstant response) : base(response)
        {
        }
    }
}
