using EventManagement.Application.DTOs.CQRSDTOs;
using EventManagement.Domain.Models;

namespace EventManagement.Application.CQRSs.EventContextCQRSs.CommandReviewEvent
{
    public class ReviewEventCommandResponse : BaseCommandResponseDTO
    {
        public ReviewEventCommandResponse(ResponseConstant response) : base(response)
        {
        }
    }
}
