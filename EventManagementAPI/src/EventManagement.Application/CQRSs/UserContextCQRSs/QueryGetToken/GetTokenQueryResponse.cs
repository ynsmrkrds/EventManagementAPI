using EventManagement.Domain.Models;

namespace EventManagement.Application.CQRSs.UserContextCQRSs.QueryGetToken
{
    public class GetTokenQueryResponse
    {
        public string Message { get; set; }

        public bool IsSuccesful { get; set; }

        public string? Token { get; set; }

        public GetTokenQueryResponse(ResponseConstant responseConstant, string? token = null)
        {
            Message = responseConstant.Message;
            IsSuccesful = responseConstant.IsSuccessful;
            Token = token;
        }
    }
}
