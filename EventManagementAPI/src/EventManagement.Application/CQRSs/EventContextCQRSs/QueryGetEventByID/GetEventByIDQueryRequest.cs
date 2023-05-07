using MediatR;

namespace EventManagement.Application.CQRSs.EventContextCQRSs.QueryGetEventByID
{
    public class GetEventByIDQueryRequest : IRequest<GetEventByIDQueryResponse>
    {
        public int EventID { get; set; }

        public GetEventByIDQueryRequest(int eventID)
        {
            EventID = eventID;
        }
    }
}
