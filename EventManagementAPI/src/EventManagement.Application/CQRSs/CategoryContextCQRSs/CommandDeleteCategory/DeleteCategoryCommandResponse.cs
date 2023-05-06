using EventManagement.Application.DTOs.CQRSDTOs;
using EventManagement.Domain.Models;

namespace EventManagement.Application.CQRSs.CategoryContextCQRSs.CommandDeleteCategory
{
    public class DeleteCategoryCommandResponse : BaseCommandResponseDTO
    {
        public DeleteCategoryCommandResponse(ResponseConstant response) : base(response)
        {
        }
    }
}
