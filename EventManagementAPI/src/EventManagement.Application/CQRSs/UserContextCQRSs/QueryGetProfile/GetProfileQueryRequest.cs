using MediatR;

namespace EventManagement.Application.CQRSs.UserContextCQRSs.QueryGetProfile
{
    public class GetProfileQueryRequest : IRequest<GetProfileQueryResponse>
    {
    }
}
