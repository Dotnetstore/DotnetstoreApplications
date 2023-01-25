using Dotnetstore.Business.Repositories;

namespace Dotnetstore.Business.Services;

public sealed class BusinessEntityService : GenericService<BusinessEntity>, IBusinessEntityService
{
    private IBusinessEntityRepository? _businessEntityRepository;

    public BusinessEntityService(IBusinessEntityRepository businessEntityRepository) : base(businessEntityRepository)
    {
        _businessEntityRepository = businessEntityRepository;
    }

    async Task<List<BusinessEntity>> IBusinessEntityService.GetAllAsync()
    {
        if (_businessEntityRepository is null)
        {
            return new List<BusinessEntity>();
        }

        return await _businessEntityRepository.GetAllAsync();
    }

    protected override void DisposeManaged()
    {
        if (!IsDisposed)
        {
            _businessEntityRepository = null;
        }

        base.DisposeManaged();
    }
}