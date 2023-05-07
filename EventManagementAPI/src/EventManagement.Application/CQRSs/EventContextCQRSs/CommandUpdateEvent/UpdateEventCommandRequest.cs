using MediatR;

namespace EventManagement.Application.CQRSs.EventContextCQRSs.CommandUpdateEvent
{
    public class UpdateEventCommandRequest : IRequest<UpdateEventCommandResponse>
    {
        public int EventID { get; set; }

        public int Quota { get; set; }

        public string Address { get; set; }

        public UpdateEventCommandRequest(int eventID, int quota, string address)
        {
            EventID = eventID;
            Quota = quota;
            Address = address;
        }
    }
}
