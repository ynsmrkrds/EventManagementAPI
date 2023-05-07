using EventManagement.Domain.Entities.EventContextEntities;
using EventManagement.Domain.Repositories.EventContextRepositories;
using EventManagement.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Infrastructure.Repositories.EventContextRepositories
{
    public class EventRepository : Repository<EventEntity>, IEventRepository
    {
        public EventRepository(EventManagementDBContext context) : base(context)
        {
        }

        public IQueryable<EventEntity> GetAll(int userID)
        {
            return _context.Events
                .AsNoTracking()
                .Where(x => x.CreatedByID == userID);
        }
    }
}
