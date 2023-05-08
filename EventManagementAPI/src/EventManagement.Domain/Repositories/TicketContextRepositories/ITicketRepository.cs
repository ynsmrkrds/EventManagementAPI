using EventManagement.Domain.Entities.TicketContextEntities;

namespace EventManagement.Domain.Repositories.TicketContextRepositories
{
    public interface ITicketRepository : IRepository<TicketEntity>
    {
        int GetTicketCountOfEvent(int eventID);

        bool IsValid(string ticketNo);

        IQueryable<TicketEntity> GetAll(int userID);
    }
}
