using EventManagement.Application.ViewModels.EventContextViewModels;

namespace EventManagement.Application.CQRSs.EventContextCQRSs.QueryGetEventByID
{
    public class GetEventByIDQueryResponse
    {
        public EventViewModel Event { get; set; }

        public GetEventByIDQueryResponse(EventViewModel @event)
        {
            Event = @event;
        }
    }
}
