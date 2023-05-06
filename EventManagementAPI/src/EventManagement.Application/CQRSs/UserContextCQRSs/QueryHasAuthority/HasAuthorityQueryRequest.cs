using MediatR;

namespace EventManagement.Application.CQRSs.UserContextCQRSs.QueryHasAuthority
{
    public class HasAuthorityQueryRequest : IRequest<HasAuthorityQueryResponse>
    {
        public int UserID { get; set; }

        public string[] Roles { get; set; }

        public HasAuthorityQueryRequest(int userID, string[] roles)
        {
            UserID = userID;
            Roles = roles;
        }
    }
}
