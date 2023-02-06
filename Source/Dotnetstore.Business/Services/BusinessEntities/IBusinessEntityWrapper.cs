namespace Dotnetstore.Business.Services.BusinessEntities;

public interface IBusinessEntityWrapper
{
    ValueTask<(bool success, Exception? error, BusinessEntity? businessEntity)> AddAsync(Guid? userID);

    Task<List<BusinessEntity>> GetAllAsync();
}