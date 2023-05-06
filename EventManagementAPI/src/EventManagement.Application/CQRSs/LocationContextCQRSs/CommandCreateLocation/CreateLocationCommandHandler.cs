using AutoMapper;
using EventManagement.Domain.Constants;
using EventManagement.Domain.Entities.LocationContextEntities;
using EventManagement.Domain.Repositories.LocationContextRepositories;
using MediatR;

namespace EventManagement.Application.CQRSs.LocationContextCQRSs.CommandCreateLocation
{
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommandRequest, CreateLocationCommandResponse>
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;

        public CreateLocationCommandHandler(ILocationRepository locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        public Task<CreateLocationCommandResponse> Handle(CreateLocationCommandRequest request, CancellationToken cancellationToken)
        {
            if (_locationRepository.IsExistsWithSameName(request.Name)) return Task.FromResult(new CreateLocationCommandResponse(ResponseConstants.ExistsLocationWithSameName));

            LocationEntity locationEntity = _mapper.Map<CreateLocationCommandRequest, LocationEntity>(request);
            _locationRepository.Add(locationEntity);

            int effectedRows = _locationRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new CreateLocationCommandResponse(ResponseConstants.CreateFailed));

            return Task.FromResult(new CreateLocationCommandResponse(ResponseConstants.SuccessfullyCreated));
        }
    }
}
