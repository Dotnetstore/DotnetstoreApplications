using Dotnetstore.Business.Repository.EF.Contexts;
using Dotnetstore.Core.Abstracts;
using Dotnetstore.Domain.Business;
using Dotnetstore.Intranet.Contract.Business;
using Microsoft.EntityFrameworkCore;

namespace Dotnetstore.Business.Repository.EF.Services;

public class SetupService : Disposable, IBusinessSetupService
{
    private IDbContextFactory<BusinessContext>? _contextFactory;

    public SetupService(IDbContextFactory<BusinessContext>? contextFactory)
    {
        _contextFactory = contextFactory;
    }

    async Task ISetupService.RunSetupAsync()
    {
        await RunMigrationAsync();
        await AddDefaultCompaniesAsync();
    }

    protected override void DisposeManaged()
    {
        if (!IsDisposed)
        {
            _contextFactory = null;
        }

        base.DisposeManaged();
    }

    private async Task AddDefaultCompaniesAsync()
    {
        var cx = await CreateContextAsync();

        if (cx is null)
        {
            return;
        }

        var company = new OwnCompany
        {
            CorporateID = "710520-1433",
            CreatedDate = DateTimeOffset.Now,
            IsDeleted = false,
            IsGDPR = false,
            IsSystem = true,
            IsUpdated = false,
            IsVisible = false,
            Name = "Dotnetstore",
            Description = "Dotnetstore development company"
        };

        cx.Entry(company).State = EntityState.Added;
        await cx.SaveChangesAsync();
    }

    private async Task<BusinessContext?> CreateContextAsync()
    {
        if (_contextFactory is null)
        {
            return null;
        }

        var cx = await _contextFactory.CreateDbContextAsync();

        if (cx is null)
        {
            return null;
        }

        return cx;
    }

    private async Task RunMigrationAsync()
    {
        var cx = await CreateContextAsync();

        if (cx is null)
        {
            return;
        }

        await cx.Database.MigrateAsync();
    }
}