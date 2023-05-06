using EventManagement.Domain.Constants;
using EventManagement.Domain.Entities.LocationContextEntities;
using EventManagement.Domain.Exceptions;
using EventManagement.Domain.Repositories.LocationContextRepositories;
using MediatR;

namespace EventManagement.Application.CQRSs.LocationContextCQRSs.CommandDeleteLocation
{
    public class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommandRequest, DeleteLocationCommandResponse>
    {
        private readonly ILocationRepository _locationRepository;

        public DeleteLocationCommandHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public Task<DeleteLocationCommandResponse> Handle(DeleteLocationCommandRequest request, CancellationToken cancellationToken)
        {
            LocationEntity locationEntity = _locationRepository.GetByID(request.ID) ?? throw new ClientSideException(ExceptionConstants.NotFoundLocation);
            _locationRepository.Delete(locationEntity);

            int effectedRows = _locationRepository.SaveChanges();
            if (effectedRows == 0) return Task.FromResult(new DeleteLocationCommandResponse(ResponseConstants.DeleteFailed));

            return Task.FromResult(new DeleteLocationCommandResponse(ResponseConstants.SuccessfullyDeleted));
        }
    }
}
