using EventManagement.Application.DTOs.CQRSDTOs;
using EventManagement.Domain.Models;

namespace EventManagement.Application.CQRSs.CategoryContextCQRSs.CommandUpdateCategory
{
    public class UpdateCategoryCommandResponse : BaseCommandResponseDTO
    {
        public UpdateCategoryCommandResponse(ResponseConstant response) : base(response)
        {
        }
    }
}
