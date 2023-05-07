using MediatR;

namespace EventManagement.Application.CQRSs.EventContextCQRSs.QueryGetAllEvents
{
    public class GetAllEventsQueryRequest : IRequest<GetAllEventsQueryResponse>
    {
    }
}
