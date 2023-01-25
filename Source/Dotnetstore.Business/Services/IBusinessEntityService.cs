namespace Dotnetstore.Business.Services;

public interface IBusinessEntityService : IGenericService<BusinessEntity>
{
    Task<List<BusinessEntity>> GetAllAsync();
}