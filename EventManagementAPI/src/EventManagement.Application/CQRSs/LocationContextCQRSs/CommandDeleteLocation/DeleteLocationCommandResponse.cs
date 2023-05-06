using EventManagement.Application.DTOs.CQRSDTOs;
using EventManagement.Domain.Models;

namespace EventManagement.Application.CQRSs.LocationContextCQRSs.CommandDeleteLocation
{
    public class DeleteLocationCommandResponse : BaseCommandResponseDTO
    {
        public DeleteLocationCommandResponse(ResponseConstant response) : base(response)
        {
        }
    }
}
