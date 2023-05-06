using EventManagement.Domain.Entities.LocationContextEntities;

namespace EventManagement.Domain.Repositories.LocationContextRepositories
{
    public interface ILocationRepository : IRepository<LocationEntity>
    {
        bool IsExistsWithSameName(string name);
    }
}
