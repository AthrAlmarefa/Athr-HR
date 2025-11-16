using Athr.Domain.Categories;

namespace Athr.Infrastructure.Repositories;

internal sealed class CategoryRepository : Repository<Category, CategoryId>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
