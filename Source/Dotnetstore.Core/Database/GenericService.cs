using Dotnetstore.Core.Abstracts;
using Dotnetstore.Core.Models;
using System.Linq.Expressions;

namespace Dotnetstore.Core.Database;

public class GenericService<T> : Disposable, IGenericService<T> where T : BaseModel
{
    internal IGenericRepository<T>? GenericRepository;

    public GenericService(
        IGenericRepository<T>? genericRepository)
    {
        GenericRepository = genericRepository;
    }

    async ValueTask<(bool success, Exception? e)> IGenericService<T>.AddAsync(T entity, Guid? userID)
    {
        if (GenericRepository is null)
        {
            return (false, new Exception("GenericRepository is null!"));
        }

        entity.CreatedDate = DateTimeOffset.Now;
        entity.CreatedByID = userID;
        entity.IsDeleted = false;
        entity.IsGDPR = false;
        entity.IsSystem = false;
        entity.IsVisible = true;
        entity.IsUpdated = true;

        return await GenericRepository.AddAsync(entity);
    }

    async ValueTask<(bool success, Exception? e)> IGenericService<T>.AddAsync(IEnumerable<T> entities, Guid? userID)
    {
        var list = entities.ToList();
        return await AddAsync(list, userID);
    }

    async ValueTask<(bool success, Exception? e)> IGenericService<T>.AddAsync(List<T> entities, Guid? userID)
    {
        return await AddAsync(entities, userID);
    }

    async ValueTask<(bool success, Exception? e)> IGenericService<T>.DeleteAsync(T entity, Guid? userID)
    {
        return await DeleteAsync(entity, userID);
    }

    async ValueTask<(bool success, Exception? e)> IGenericService<T>.DeleteAsync(IEnumerable<T> entities, Guid? userID)
    {
        var list = entities.ToList();
        return await DeleteAsync(list, userID);
    }

    async ValueTask<(bool success, Exception? e)> IGenericService<T>.DeleteAsync(List<T> entities, Guid? userID)
    {
        return await DeleteAsync(entities, userID);
    }

    async Task<T?> IGenericService<T>.FindAsync(Guid id)
    {
        if (GenericRepository is null)
        {
            return null;
        }

        return await GenericRepository.FindAsync(id);
    }

    async Task<List<T>?> IGenericService<T>.FindAsync(Expression<Func<T, bool>> predicate)
    {
        if (GenericRepository is null)
        {
            return null;
        }

        return await GenericRepository.FindAsync(predicate);
    }

    async ValueTask<(bool success, Exception? e)> IGenericService<T>.SaveAsync(T entity, Guid? userID)
    {
        return await SaveAsync(entity, userID);
    }

    async ValueTask<(bool success, Exception? e)> IGenericService<T>.SaveAsync(IEnumerable<T> entities, Guid? userID)
    {
        var list = entities.ToList();
        return await SaveAsync(list, userID);
    }

    async ValueTask<(bool success, Exception? e)> IGenericService<T>.SaveAsync(List<T> entities, Guid? userID)
    {
        return await SaveAsync(entities, userID);
    }

    protected override void DisposeManaged()
    {
        if (!IsDisposed)
        {
            GenericRepository = null;
        }

        base.DisposeManaged();
    }

    private async ValueTask<(bool success, Exception? e)> AddAsync(IList<T> entities, Guid? userID)
    {
        if (GenericRepository is null)
        {
            return (false, new Exception("GenericRepository is null!"));
        }

        var listOfEntities = new List<T>();

        foreach (var entity in entities)
        {
            entity.CreatedDate = DateTime.Now;
            entity.CreatedByID = userID;
            listOfEntities.Add(entity);
        }

        return await GenericRepository.AddAsync(listOfEntities);
    }

    private async ValueTask<(bool success, Exception? e)> DeleteAsync(T entity, Guid? userID)
    {
        entity.IsDeleted = true;
        entity.DeletedDate = DateTimeOffset.Now;
        entity.DeletedByID = userID;

        return await SaveAsync(entity, userID);
    }

    private async ValueTask<(bool success, Exception? e)> DeleteAsync(IList<T> entities, Guid? userID)
    {
        var listOfEntities = new List<T>();

        foreach (var entity in entities)
        {
            entity.IsDeleted = true;
            entity.DeletedDate = DateTimeOffset.Now;
            entity.DeletedByID = userID;
            listOfEntities.Add(entity);
        }

        return await SaveAsync(listOfEntities, userID);
    }

    private async ValueTask<(bool success, Exception? e)> SaveAsync(T entity, Guid? userID)
    {
        if (GenericRepository is null)
        {
            return (false, new Exception("GenericRepository is null!"));
        }

        entity.IsUpdated = true;
        entity.LastUpdatedDate = DateTimeOffset.Now;
        entity.LastUpdatedByID = userID;

        return await GenericRepository.SaveAsync(entity);
    }

    private async ValueTask<(bool success, Exception? e)> SaveAsync(IList<T> entities, Guid? userID)
    {
        if (GenericRepository is null)
        {
            return (false, new Exception("GenericRepository is null!"));
        }

        var listOfEntities = new List<T>();

        foreach (var entity in entities)
        {
            entity.IsUpdated = true;
            entity.LastUpdatedDate = DateTimeOffset.Now;
            entity.LastUpdatedByID = userID;
            listOfEntities.Add(entity);
        }

        return await GenericRepository.SaveAsync(listOfEntities);
    }
}