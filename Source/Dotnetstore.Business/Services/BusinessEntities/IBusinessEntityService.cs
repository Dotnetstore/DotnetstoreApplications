using Dotnetstore.Business.Services.Helpers;

namespace Dotnetstore.Business.Services.BusinessEntities;

public interface IBusinessEntityService : IGenericService<BusinessEntity>
{
    Task<List<BusinessEntity>> GetAllAsync();
}