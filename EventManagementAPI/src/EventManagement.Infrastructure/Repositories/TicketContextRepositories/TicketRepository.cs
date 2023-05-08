using EventManagement.Domain.Entities.TicketContextEntities;
using EventManagement.Domain.Repositories.TicketContextRepositories;
using EventManagement.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Infrastructure.Repositories.TicketContextRepositories
{
    public class TicketRepository : Repository<TicketEntity>, ITicketRepository
    {
        public TicketRepository(EventManagementDBContext context) : base(context)
        {
        }

        public int GetTicketCountOfEvent(int eventID)
        {
            return _context.Tickets
                .Where(x => x.EventID == eventID)
                .Count();
        }

        public bool IsValid(string ticketNo)
        {
            return _context.Tickets
                .Where(x => x.TicketNo == ticketNo)
                .Any();
        }

        public IQueryable<TicketEntity> GetAll(int userID)
        {
            return _context.Tickets
                .Where(x => x.PurchasedByID == userID)
                .AsNoTracking();
        }
    }
}
