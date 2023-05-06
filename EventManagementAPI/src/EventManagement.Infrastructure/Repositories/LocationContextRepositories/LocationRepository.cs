using EventManagement.Domain.Entities.LocationContextEntities;
using EventManagement.Domain.Repositories.LocationContextRepositories;
using EventManagement.Infrastructure.Context;

namespace EventManagement.Infrastructure.Repositories.LocationContextRepositories
{
    public class LocationRepository : Repository<LocationEntity>, ILocationRepository
    {
        public LocationRepository(EventManagementDBContext context) : base(context)
        {
        }

        public bool IsExistsWithSameName(string name)
        {
            return _context.Categories
                .Where(x => x.Name == name)
                .Any();
        }
    }
}
