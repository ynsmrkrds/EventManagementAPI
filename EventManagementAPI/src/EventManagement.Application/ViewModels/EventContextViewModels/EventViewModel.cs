using EventManagement.Application.ViewModels.CategoryContextViewModels;
using EventManagement.Application.ViewModels.LocationContextViewModels;
using EventManagement.Application.ViewModels.UserContextViewModels;
using EventManagement.Domain.Enums.CategoryContextEnums;

namespace EventManagement.Application.ViewModels.EventContextViewModels
{
    public class EventViewModel : BaseViewModel
    {
        public string Title { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public LocationViewModel Location { get; set; }

        public string Address { get; set; }

        public int Quota { get; set; }

        public CategoryViewModel Category { get; set; }

        public UserViewModel CreatedBy { get; set; }

        public EventStatus Status { get; set; }

        public EventViewModel(int id, DateTime createdDate, string title, DateTime date, string description, LocationViewModel location, string address, int quota, CategoryViewModel category, UserViewModel createdBy, EventStatus status) : base(id, createdDate)
        {
            Title = title;
            Date = date;
            Description = description;
            Location = location;
            Address = address;
            Quota = quota;
            Category = category;
            CreatedBy = createdBy;
            Status = status;
        }
    }
}
