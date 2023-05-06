using AutoMapper;
using EventManagement.Domain.Constants;
using EventManagement.Domain.Entities.LocationContextEntities;
using EventManagement.Domain.Exceptions;
using EventManagement.Domain.Repositories.LocationContextRepositories;
using MediatR;

namespace EventManagement.Application.CQRSs.LocationContextCQRSs.CommandUpdateLocation
{
    public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommandRequest, UpdateLocationCommandResponse>
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;

        public UpdateLocationCommandHandler(ILocationRepository locationRepository, IMapper mapper)
        {
            _locationRepository = locationRepository;
            _mapper = mapper;
        }

        public Task<UpdateLocationCommandResponse> Handle(UpdateLocationCommandRequest request, CancellationToken cancellationToken)
        {
            LocationEntity locationEntity = _locationRepository.GetByID(request.ID) ?? throw new ClientSideException(ExceptionConstants.NotFoundLocation);

            _mapper.Map(request, locationEntity);
            _locationRepository.Update(locationEntity);

            int effectedRows = _locationRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new UpdateLocationCommandResponse(ResponseConstants.UpdateFailed));

            return Task.FromResult(new UpdateLocationCommandResponse(ResponseConstants.SuccessfullyUpdated));
        }
    }
}
