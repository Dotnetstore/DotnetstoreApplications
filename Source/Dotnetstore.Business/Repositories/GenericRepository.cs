using Dotnetstore.Core.Abstracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Dotnetstore.Business.Repositories;

public class GenericRepository<T, TU> : Disposable, IGenericRepository<T> where T : class where TU : DbContext
{
    internal IDbContextFactory<TU>? ContextFactory;

    public GenericRepository(IDbContextFactory<TU>? contextFactory)
    {
        ContextFactory = contextFactory;
    }

    async ValueTask<(bool success, Exception? e)> IGenericRepository<T>.AddAsync(T entity)
    {
        return await DoOperationAsync(entity, EntityState.Added);
    }

    async ValueTask<(bool success, Exception? e)> IGenericRepository<T>.AddAsync(IEnumerable<T> entities)
    {
        return await DoOperationAsync(entities, EntityState.Added);
    }

    async ValueTask<(bool success, Exception? e)> IGenericRepository<T>.AddAsync(IList<T> entities)
    {
        return await DoOperationAsync(entities, EntityState.Added);
    }

    async ValueTask<(bool success, Exception? e)> IGenericRepository<T>.DeleteAsync(T entity)
    {
        return await DoOperationAsync(entity, EntityState.Deleted);
    }

    async ValueTask<(bool success, Exception? e)> IGenericRepository<T>.DeleteAsync(IEnumerable<T> entities)
    {
        return await DoOperationAsync(entities, EntityState.Deleted);
    }

    async ValueTask<(bool success, Exception? e)> IGenericRepository<T>.DeleteAsync(IList<T> entities)
    {
        return await DoOperationAsync(entities, EntityState.Deleted);
    }

    async Task<T?> IGenericRepository<T>.FindAsync(Guid id)
    {
        var cx = await CreateContextAsync();

        if (cx is null)
        {
            return null;
        }

        return await cx.Set<T>().FindAsync(id);
    }

    async Task<List<T>?> IGenericRepository<T>.FindAsync(Expression<Func<T, bool>> predicate)
    {
        var cx = await CreateContextAsync();

        if (cx is null)
        {
            return null;
        }

        return await cx.Set<T>().Where(predicate).ToListAsync();
    }

    async ValueTask<(bool success, Exception? e)> IGenericRepository<T>.SaveAsync(T entity)
    {
        return await DoOperationAsync(entity, EntityState.Modified);
    }

    async ValueTask<(bool success, Exception? e)> IGenericRepository<T>.SaveAsync(IEnumerable<T> entities)
    {
        return await DoOperationAsync(entities, EntityState.Modified);
    }

    async ValueTask<(bool success, Exception? e)> IGenericRepository<T>.SaveAsync(IList<T> entities)
    {
        return await DoOperationAsync(entities, EntityState.Modified);
    }

    internal async Task<TU?> CreateContextAsync()
    {
        if (ContextFactory is null)
        {
            return null;
        }

        return await ContextFactory.CreateDbContextAsync();
    }

    protected override void DisposeManaged()
    {
        if (!IsDisposed)
        {
            ContextFactory = null;
        }

        base.DisposeManaged();
    }

    private async ValueTask<(bool success, Exception? e)> DoOperationAsync(T entity, EntityState entityState)
    {
        try
        {
            var cx = await CreateContextAsync();

            if (cx is null)
            {
                return (false, new Exception("Context is null!"));
            }

            cx.Entry(entity).State = entityState;

            await cx.SaveChangesAsync();
            return (success: true, e: null);
        }
        catch (Exception e)
        {
            return (success: false, e);
        }
    }

    private async ValueTask<(bool success, Exception? e)> DoOperationAsync(IEnumerable<T> entities, EntityState entityState)
    {
        try
        {
            var cx = await CreateContextAsync();

            if (cx is null)
            {
                return (false, new Exception("Context is null!"));
            }

            foreach (var entity in entities)
            {
                cx.Entry(entity).State = entityState;
            }

            await cx.SaveChangesAsync();
            return (success: true, e: null);
        }
        catch (Exception e)
        {
            return (success: false, e);
        }
    }
}