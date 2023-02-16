using Dotnetstore.Core.Abstracts;

namespace Dotnetstore.UnitOfWorks.Intranet.Frontend.Businesses;

public class BusinessService : Disposable, IBusinessService
{
    private IOwnCompanyService? _ownCompanyService;

    IOwnCompanyService IBusinessService.OwnCompany => _ownCompanyService;

    public BusinessService(
        IOwnCompanyService ownCompanyService)
    {
        _ownCompanyService = ownCompanyService;
    }

    protected override void DisposeManaged()
    {
        if (!IsDisposed)
        {
            _ownCompanyService = null;
        }

        base.DisposeManaged();
    }
}