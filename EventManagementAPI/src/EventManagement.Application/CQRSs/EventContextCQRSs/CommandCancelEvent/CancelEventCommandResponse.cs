using EventManagement.Application.DTOs.CQRSDTOs;
using EventManagement.Domain.Models;

namespace EventManagement.Application.CQRSs.EventContextCQRSs.CommandCancelEvent
{
    public class CancelEventCommandResponse : BaseCommandResponseDTO
    {
        public CancelEventCommandResponse(ResponseConstant response) : base(response)
        {
        }
    }
}
