using EventManagement.Application.DTOs.CQRSDTOs;
using EventManagement.Domain.Models;

namespace EventManagement.Application.CQRSs.CategoryContextCQRSs.CommandCreateCategory
{
    public class CreateCategoryCommandResponse : BaseCommandResponseDTO
    {
        public CreateCategoryCommandResponse(ResponseConstant response) : base(response)
        {
        }
    }
}
