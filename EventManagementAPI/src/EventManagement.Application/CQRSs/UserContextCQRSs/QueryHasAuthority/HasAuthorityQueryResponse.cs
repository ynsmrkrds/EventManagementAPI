namespace EventManagement.Application.CQRSs.UserContextCQRSs.QueryHasAuthority
{
    public class HasAuthorityQueryResponse
    {
        public bool HasAuthority { get; set; }

        public HasAuthorityQueryResponse(bool hasAuthority)
        {
            HasAuthority = hasAuthority;
        }
    }
}
