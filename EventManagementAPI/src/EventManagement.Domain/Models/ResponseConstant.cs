namespace EventManagement.Domain.Models
{
    public class ResponseConstant
    {
        public bool IsSuccessful { get; set; }

        public string Message { get; set; }

        public ResponseConstant(bool isSuccessful, string message)
        {
            IsSuccessful = isSuccessful;
            Message = message;
        }
    }
}
