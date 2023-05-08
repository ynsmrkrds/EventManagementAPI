using EventManagement.Application.DTOs.CQRSDTOs;
using EventManagement.Domain.Models;

namespace EventManagement.Application.CQRSs.TicketContextCQRSs.CommandPurchaseTicket
{
    public class PurchaseTicketCommandResponse : BaseCommandResponseDTO
    {
        public PurchaseTicketCommandResponse(ResponseConstant response) : base(response)
        {
        }
    }
}
