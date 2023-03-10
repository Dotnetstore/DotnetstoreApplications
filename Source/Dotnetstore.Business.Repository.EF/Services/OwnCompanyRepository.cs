using Dotnetstore.Business.Repository.EF.Contexts;
using Dotnetstore.Core.Database;
using Dotnetstore.Domain.Business;
using Dotnetstore.Intranet.Contract.Business;
using Microsoft.EntityFrameworkCore;

namespace Dotnetstore.Business.Repository.EF.Services;

public sealed class OwnCompanyRepository : GenericRepository<OwnCompany, BusinessContext>, IOwnCompanyRepository
{
    public OwnCompanyRepository(IDbContextFactory<BusinessContext>? contextFactory) : base(contextFactory)
    {
    }

    async Task<List<OwnCompany>> IOwnCompanyRepository.GetAllAsync()
    {
        var cx = await GetContextAsync();

        if (cx is null)
        {
            return new List<OwnCompany>();
        }

        return await cx.OwnCompanies
            .Where(q => q.IsVisible.HasValue && q.IsVisible.Value)
            .OrderBy(q => q.Name)
            .ThenBy(q => q.CorporateID)
            .AsNoTracking()
            .ToListAsync();
    }

    async Task<List<OwnCompany>> IOwnCompanyRepository.GetAllAvailableAsync()
    {
        var cx = await GetContextAsync();

        if (cx is null)
        {
            return new List<OwnCompany>();
        }

        return await cx.OwnCompanies
            .Where(q => (!q.IsDeleted.HasValue || q.IsDeleted.HasValue && !q.IsDeleted.Value) &&
                        q.IsVisible.HasValue && q.IsVisible.Value)
            .OrderBy(q => q.Name)
            .ThenBy(q => q.CorporateID)
            .AsNoTracking()
            .ToListAsync();
    }

    async Task<List<OwnCompany>> IOwnCompanyRepository.GetAllDeletedAsync()
    {
        var cx = await GetContextAsync();

        if (cx is null)
        {
            return new List<OwnCompany>();
        }

        return await cx.OwnCompanies
            .Where(q => q.IsDeleted.HasValue && q.IsDeleted.Value &&
                        q.IsVisible.HasValue && q.IsVisible.Value)
            .OrderBy(q => q.Name)
            .ThenBy(q => q.CorporateID)
            .AsNoTracking()
            .ToListAsync();
    }

    private async Task<BusinessContext?> GetContextAsync()
    {
        if (ContextFactory is null)
        {
            return null;
        }

        return await ContextFactory.CreateDbContextAsync();
    }
}