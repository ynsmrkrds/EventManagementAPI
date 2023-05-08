using EventManagement.Application.DTOs.CQRSDTOs;
using EventManagement.Domain.Models;

namespace EventManagement.Application.CQRSs.TicketContextCQRSs.CommandCheckTicket
{
    public class CheckTicketCommandResponse : BaseCommandResponseDTO
    {
        public CheckTicketCommandResponse(ResponseConstant response) : base(response)
        {
        }
    }
}
