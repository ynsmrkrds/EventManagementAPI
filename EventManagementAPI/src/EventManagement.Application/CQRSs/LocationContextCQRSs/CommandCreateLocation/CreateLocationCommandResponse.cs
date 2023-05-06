using EventManagement.Application.DTOs.CQRSDTOs;
using EventManagement.Domain.Models;

namespace EventManagement.Application.CQRSs.LocationContextCQRSs.CommandCreateLocation
{
    public class CreateLocationCommandResponse : BaseCommandResponseDTO
    {
        public CreateLocationCommandResponse(ResponseConstant response) : base(response)
        {
        }
    }
}
