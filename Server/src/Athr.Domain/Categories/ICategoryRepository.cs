using Athr.Domain.BusinessRoles;
using Athr.Domain.Users;
using System.Linq.Expressions;

namespace Athr.Domain.Categories;

public interface ICategoryRepository
{
    Task<Category?> GetByIdAsync(
        CategoryId userId,
        CancellationToken cancellationToken = default);
    IQueryable<Category> All();

    Task AddAsync(Category unit);
    void Update(Category unit);
}
