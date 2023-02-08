using Dotnetstore.Business.Services.Helpers;

namespace Dotnetstore.Business.Services.BusinessEntities;

public interface IBusinessEntityRepository : IGenericRepository<BusinessEntity>
{
    Task<List<BusinessEntity>> GetAllAsync();
}