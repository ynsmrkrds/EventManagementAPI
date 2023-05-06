using EventManagement.Application.ViewModels.LocationContextViewModels;

namespace EventManagement.Application.CQRSs.LocationContextCQRSs.QueryGetAllLocations
{
    public class GetAllLocationsQueryResponse
    {
        public ICollection<LocationViewModel> Locations { get; set; }

        public GetAllLocationsQueryResponse(ICollection<LocationViewModel> locations)
        {
            Locations = locations;
        }
    }
}
