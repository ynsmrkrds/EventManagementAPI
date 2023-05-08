using MediatR;

namespace EventManagement.Application.CQRSs.EventContextCQRSs.QueryGetParticipatedEvents
{
    public class GetParticipatedEventsQueryRequest : IRequest<GetParticipatedEventsQueryResponse>
    {
    }
}
