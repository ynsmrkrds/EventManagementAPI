using EventManagement.Application.DTOs.CQRSDTOs;
using EventManagement.Domain.Models;

namespace EventManagement.Application.CQRSs.EventContextCQRSs.CommandCreateEvent
{
    public class CreateEventCommandResponse : BaseCommandResponseDTO
    {
        public CreateEventCommandResponse(ResponseConstant response) : base(response)
        {
        }
    }
}
