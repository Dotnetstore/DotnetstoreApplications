using Dotnetstore.Business.Services;
using Dotnetstore.Core.Abstracts;

namespace Dotnetstore.Business.Wrappers;

public sealed class BusinessEntityWrapper : Disposable, IBusinessEntityWrapper
{
    private IBusinessEntityService? _businessEntityService;

    public BusinessEntityWrapper(
        IBusinessEntityService businessEntityService)
    {
        _businessEntityService = businessEntityService;
    }

    async ValueTask<(bool success, Exception? error, BusinessEntity? businessEntity)> IBusinessEntityWrapper.AddAsync(Guid? userID)
    {
        if (_businessEntityService is null)
        {
            return (false, new Exception("_businessEntityService is null"), null);
        }

        var businessEntity = new BusinessEntity();
        var (success, exception) = await _businessEntityService.AddAsync(businessEntity, userID);
        return (success, exception, businessEntity);
    }

    async Task<List<BusinessEntity>> IBusinessEntityWrapper.GetAllAsync()
    {
        if (_businessEntityService is null)
        {
            return new List<BusinessEntity>();
        }

        return await _businessEntityService.GetAllAsync();
    }

    protected override void DisposeManaged()
    {
        if (!IsDisposed)
        {
            _businessEntityService = null;
        }

        base.DisposeManaged();
    }
}