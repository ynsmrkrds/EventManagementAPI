using EventManagement.Domain.Models;

namespace EventManagement.Application.DTOs.CQRSDTOs
{
    public abstract class BaseCommandResponseDTO
    {
        public bool IsSuccessful { get; set; }

        public string Message { get; set; }

        protected BaseCommandResponseDTO(ResponseConstant response)
        {
            IsSuccessful = response.IsSuccessful;
            Message = response.Message;
        }
    }
}
