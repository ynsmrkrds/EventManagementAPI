using EventManagement.Application.ViewModels.EventContextViewModels;

namespace EventManagement.Application.CQRSs.EventContextCQRSs.QueryGetOrganizedEvents
{
    public class GetOrganizedEventsQueryResponse
    {
        public ICollection<EventViewModel> Events { get; set; }

        public GetOrganizedEventsQueryResponse(ICollection<EventViewModel> events)
        {
            Events = events;
        }
    }
}
