using EventManagement.Domain.Enums.CategoryContextEnums;
using MediatR;

namespace EventManagement.Application.CQRSs.EventContextCQRSs.CommandCreateEvent
{
    public class CreateEventCommandRequest : IRequest<CreateEventCommandResponse>
    {
        public string Title { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public int LocationID { get; set; }

        public string Address { get; set; }

        public int Quota { get; set; }

        public int CategoryID { get; set; }

        public CreateEventCommandRequest(string title, DateTime date, string description, int locationID, string address, int quota, int categoryID)
        {
            Title = title;
            Date = date;
            Description = description;
            LocationID = locationID;
            Address = address;
            Quota = quota;
            CategoryID = categoryID;
        }
    }
}
