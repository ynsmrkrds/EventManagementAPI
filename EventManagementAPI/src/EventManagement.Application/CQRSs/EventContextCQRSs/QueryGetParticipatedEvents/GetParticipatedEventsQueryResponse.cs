using EventManagement.Application.ViewModels.EventContextViewModels;

namespace EventManagement.Application.CQRSs.EventContextCQRSs.QueryGetParticipatedEvents
{
    public class GetParticipatedEventsQueryResponse
    {
        public ICollection<EventViewModel> Events { get; set; }

        public GetParticipatedEventsQueryResponse(ICollection<EventViewModel> events)
        {
            Events = events;
        }
    }
}
