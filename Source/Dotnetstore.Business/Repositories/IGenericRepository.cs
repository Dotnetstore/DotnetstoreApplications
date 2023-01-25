using System.Linq.Expressions;

namespace Dotnetstore.Business.Repositories;

public interface IGenericRepository<T> where T : class
{
    ValueTask<(bool success, Exception? e)> AddAsync(T entity);

    ValueTask<(bool success, Exception? e)> AddAsync(IEnumerable<T> entities);

    ValueTask<(bool success, Exception? e)> AddAsync(IList<T> entities);

    ValueTask<(bool success, Exception? e)> DeleteAsync(T entity);

    ValueTask<(bool success, Exception? e)> DeleteAsync(IEnumerable<T> entities);

    ValueTask<(bool success, Exception? e)> DeleteAsync(IList<T> entities);

    Task<T?> FindAsync(Guid id);

    Task<List<T>?> FindAsync(Expression<Func<T, bool>> predicate);

    ValueTask<(bool success, Exception? e)> SaveAsync(T entity);

    ValueTask<(bool success, Exception? e)> SaveAsync(IEnumerable<T> entities);

    ValueTask<(bool success, Exception? e)> SaveAsync(IList<T> entities);
}