using MediatR;

namespace EventManagement.Application.CQRSs.EventContextCQRSs.QueryGetOrganizedEvents
{
    public class GetOrganizedEventsQueryRequest : IRequest<GetOrganizedEventsQueryResponse>
    {
    }
}
