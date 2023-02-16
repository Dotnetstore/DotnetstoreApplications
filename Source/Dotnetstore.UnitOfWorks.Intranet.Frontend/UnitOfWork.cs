using Dotnetstore.Core.Abstracts;
using Dotnetstore.UnitOfWorks.Intranet.Frontend.Businesses;

namespace Dotnetstore.UnitOfWorks.Intranet.Frontend;

public class UnitOfWork : Disposable, IUnitOfWork
{
    private IBusinessService? _businessService;

    public UnitOfWork(
        IBusinessService businessService)
    {
        _businessService = businessService;
    }

    IBusinessService? IUnitOfWork.Business => _businessService;

    protected override void DisposeManaged()
    {
        if (!IsDisposed)
        {
            _businessService = null;
        }

        base.DisposeManaged();
    }
}