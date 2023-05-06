using AutoMapper;
using EventManagement.Application.ViewModels.LocationContextViewModels;
using EventManagement.Domain.Entities.LocationContextEntities;
using EventManagement.Domain.Repositories.LocationContextRepositories;
using MediatR;

namespace EventManagement.Application.CQRSs.LocationContextCQRSs.QueryGetAllLocations
{
    public class GetAllLocationsQueryHandler : IRequestHandler<GetAllLocationsQueryRequest, GetAllLocationsQueryResponse>
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;

        public GetAllLocationsQueryHandler(ILocationRepository locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        public Task<GetAllLocationsQueryResponse> Handle(GetAllLocationsQueryRequest request, CancellationToken cancellationToken)
        {
            List<LocationEntity> locations = _locationRepository.GetAll().ToList();

            List<LocationViewModel> viewModels = _mapper.Map<List<LocationEntity>, List<LocationViewModel>>(locations);

            return Task.FromResult(new GetAllLocationsQueryResponse(viewModels));

        }
    }
}
