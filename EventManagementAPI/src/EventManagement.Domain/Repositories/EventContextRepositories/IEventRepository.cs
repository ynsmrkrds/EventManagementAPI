using EventManagement.Domain.Entities.EventContextEntities;

namespace EventManagement.Domain.Repositories.EventContextRepositories
{
    public interface IEventRepository : IRepository<EventEntity>
    {
        IQueryable<EventEntity> GetAll(int userID);
    }
}
