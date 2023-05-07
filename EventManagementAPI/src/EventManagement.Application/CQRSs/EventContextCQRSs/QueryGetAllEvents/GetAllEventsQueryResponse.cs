using EventManagement.Application.ViewModels.EventContextViewModels;

namespace EventManagement.Application.CQRSs.EventContextCQRSs.QueryGetAllEvents
{
    public class GetAllEventsQueryResponse
    {
        public ICollection<EventViewModel> Events { get; set; }

        public GetAllEventsQueryResponse(ICollection<EventViewModel> events)
        {
            Events = events;
        }
    }
}
