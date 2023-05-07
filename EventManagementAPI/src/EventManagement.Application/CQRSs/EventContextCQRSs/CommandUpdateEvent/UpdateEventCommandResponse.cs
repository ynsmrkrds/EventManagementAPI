using EventManagement.Application.DTOs.CQRSDTOs;
using EventManagement.Domain.Models;

namespace EventManagement.Application.CQRSs.EventContextCQRSs.CommandUpdateEvent
{
    public class UpdateEventCommandResponse : BaseCommandResponseDTO
    {
        public UpdateEventCommandResponse(ResponseConstant response) : base(response)
        {
        }
    }
}
