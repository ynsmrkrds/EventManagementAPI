using EventManagement.Domain.Entities.CategoryContextEntities;

namespace EventManagement.Domain.Repositories.CategoryContextRepositories
{
    public interface ICategoryRepository : IRepository<CategoryEntity>
    {
        bool IsExistsWithSameName(string name);
    }
}
