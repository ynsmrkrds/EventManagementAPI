using EventManagement.Domain.Entities.CategoryContextEntities;
using EventManagement.Domain.Repositories.CategoryContextRepositories;
using EventManagement.Infrastructure.Context;

namespace EventManagement.Infrastructure.Repositories.CategoryContextRepositories
{
    public class CategoryRepository : Repository<CategoryEntity>, ICategoryRepository
    {
        public CategoryRepository(EventManagementDBContext context) : base(context)
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
