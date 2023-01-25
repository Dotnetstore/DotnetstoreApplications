namespace Dotnetstore.Business.Repositories;

public interface IBusinessEntityRepository : IGenericRepository<BusinessEntity>
{
    Task<List<BusinessEntity>> GetAllAsync();
}