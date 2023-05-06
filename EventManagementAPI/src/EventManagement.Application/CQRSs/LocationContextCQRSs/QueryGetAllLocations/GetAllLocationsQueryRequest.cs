using MediatR;

namespace EventManagement.Application.CQRSs.LocationContextCQRSs.QueryGetAllLocations
{
    public class GetAllLocationsQueryRequest : IRequest<GetAllLocationsQueryResponse>
    {
    }
}
