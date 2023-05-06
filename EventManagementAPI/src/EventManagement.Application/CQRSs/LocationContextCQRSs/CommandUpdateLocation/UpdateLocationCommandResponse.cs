using EventManagement.Application.DTOs.CQRSDTOs;
using EventManagement.Domain.Models;

namespace EventManagement.Application.CQRSs.LocationContextCQRSs.CommandUpdateLocation
{
    public class UpdateLocationCommandResponse : BaseCommandResponseDTO
    {
        public UpdateLocationCommandResponse(ResponseConstant response) : base(response)
        {
        }
    }
}
