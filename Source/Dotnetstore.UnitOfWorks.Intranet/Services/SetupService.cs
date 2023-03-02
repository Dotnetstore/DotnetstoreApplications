using Dotnetstore.Business.Repository.EF.Services;
using Dotnetstore.Core.Abstracts;
using Dotnetstore.Intranet.Contract.Business;
using Dotnetstore.UnitOfWorks.Intranet.Interfaces;

namespace Dotnetstore.UnitOfWorks.Intranet.Services;

public class SetupService : Disposable, IUnitOfWorkSetupService
{
    private IBusinessSetupService? _businessSetupService;

    public SetupService(
        IBusinessSetupService businessSetupService)
    {
        _businessSetupService = businessSetupService;
    }

    async Task ISetupService.RunSetupAsync()
    {
        if (_businessSetupService is null)
        {
            return;
        }

        await _businessSetupService.RunSetupAsync();
    }

    protected override void DisposeManaged()
    {
        if (!IsDisposed)
        {
            _businessSetupService = null;
        }

        base.DisposeManaged();
    }
}