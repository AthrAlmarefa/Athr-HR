using Athr.Domain.BuildingBlocks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Athr.Infrastructure.Repositories;

internal abstract class Repository<T, TId> where T : Entity<TId> where TId : notnull
{
    protected readonly ApplicationDbContext DbContext;

    protected Repository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public async Task<T?> GetByIdAsync(
        TId id,
        CancellationToken cancellationToken = default)
    {
        return await All().FirstOrDefaultAsync(entity => entity.Id.Equals(id), cancellationToken);
    }

    public IQueryable<T> All()
    {
        return DbContext.Set<T>().AsQueryable();
    }

    public virtual async Task AddAsync(T entity)
    {
        //EntityStateDetached(entity);
        await DbContext.AddAsync(entity);
    }

    public virtual void Update(T entity)
    {
        DbContext.Update(entity);
    }

    public virtual void Delete(T entity)
    {
        DbContext.Remove(entity);
    }

}
