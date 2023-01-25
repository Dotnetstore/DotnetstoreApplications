using System.Linq.Expressions;

namespace Dotnetstore.Business.Services;

public interface IGenericService<T> where T : class
{
    ValueTask<(bool success, Exception? e)> AddAsync(T entity, Guid? userID);

    ValueTask<(bool success, Exception? e)> AddAsync(IEnumerable<T> entities, Guid? userID);

    ValueTask<(bool success, Exception? e)> AddAsync(List<T> entities, Guid? userID);

    ValueTask<(bool success, Exception? e)> DeleteAsync(T entity, Guid? userID);

    ValueTask<(bool success, Exception? e)> DeleteAsync(IEnumerable<T> entities, Guid? userID);

    ValueTask<(bool success, Exception? e)> DeleteAsync(List<T> entities, Guid? userID);

    Task<T?> FindAsync(Guid id);

    Task<List<T>?> FindAsync(Expression<Func<T, bool>> predicate);

    ValueTask<(bool success, Exception? e)> SaveAsync(T entity, Guid? userID);

    ValueTask<(bool success, Exception? e)> SaveAsync(IEnumerable<T> entities, Guid? userID);

    ValueTask<(bool success, Exception? e)> SaveAsync(List<T> entities, Guid? userID);
}