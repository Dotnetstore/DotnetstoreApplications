using Microsoft.EntityFrameworkCore;

namespace Dotnetstore.Business.Repositories;

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
            .Where(q => !q.IsDeleted.HasValue || (q.IsDeleted.HasValue && !q.IsDeleted.Value))
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
            .Where(q => q.IsDeleted.HasValue && q.IsDeleted.Value)
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