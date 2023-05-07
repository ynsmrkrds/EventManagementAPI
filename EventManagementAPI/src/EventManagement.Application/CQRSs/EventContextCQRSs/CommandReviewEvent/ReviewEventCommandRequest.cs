using EventManagement.Domain.Enums.CategoryContextEnums;
using MediatR;

namespace EventManagement.Application.CQRSs.EventContextCQRSs.CommandReviewEvent
{
    public class ReviewEventCommandRequest : IRequest<ReviewEventCommandResponse>
    {
        public int EventID { get; set; }

        public EventStatus Status { get; set; }

        public ReviewEventCommandRequest(int eventID, EventStatus status)
        {
            EventID = eventID;
            Status = status;
        }
    }
}
