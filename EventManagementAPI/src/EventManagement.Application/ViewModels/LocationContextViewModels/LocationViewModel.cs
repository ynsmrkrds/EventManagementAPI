namespace EventManagement.Application.ViewModels.LocationContextViewModels
{
    public class LocationViewModel : BaseViewModel
    {
        public string Name { get; set; }

        public LocationViewModel(int id, DateTime createdDate, string name) : base(id, createdDate)
        {
            Name = name;
        }
    }
}
