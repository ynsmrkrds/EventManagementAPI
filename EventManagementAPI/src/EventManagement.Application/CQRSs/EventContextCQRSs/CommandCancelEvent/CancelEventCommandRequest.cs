using EventManagement.Domain.Enums.CategoryContextEnums;
using MediatR;

namespace EventManagement.Application.CQRSs.EventContextCQRSs.CommandCancelEvent
{
    public class CancelEventCommandRequest : IRequest<CancelEventCommandResponse>
    {
        public int EventID { get; set; }

        public EventStatus Status { get; set; }

        public CancelEventCommandRequest(int eventID)
        {
            EventID = eventID;
            Status = EventStatus.Canceled;
        }
    }
}
