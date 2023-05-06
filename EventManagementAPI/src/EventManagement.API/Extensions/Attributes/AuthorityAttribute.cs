using EventManagement.Application.CQRSs.UserContextCQRSs.QueryHasAuthority;
using EventManagement.Application.Helpers;
using EventManagement.Domain.Constants;
using EventManagement.Domain.Exceptions;
using EventManagement.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EventManagement.API.Extensions.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AuthorityAttribute : ActionFilterAttribute
    {
        private readonly List<string> _roles;

        public AuthorityAttribute(string role, params string[] roles)
        {
            _roles = new List<string>() { role };
            _roles.AddRange(roles);
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string? token = TokenHelper.Instance().GetTokenInRequest() ?? throw new ClientSideException(ExceptionConstants.TokenError);
            TokenModel tokenModel = TokenHelper.Instance().DecodeToken(token);

            IMediator mediator = context.HttpContext.RequestServices.GetRequiredService<IMediator>();
            HasAuthorityQueryResponse queryResponse = mediator.Send(new HasAuthorityQueryRequest(tokenModel.UserID, _roles.ToArray())).Result;
            if (queryResponse.HasAuthority == false)
            {
                throw new ClientSideException(ExceptionConstants.NoAuthority);
            }
        }
    }
}
