using Microsoft.EntityFrameworkCore;

namespace Dotnetstore.Business.Contexts;

public sealed class BusinessContext : DbContext
{
    public DbSet<BusinessEntity> BusinessEntities => Set<BusinessEntity>();

    public DbSet<OwnCompany> OwnCompanies => Set<OwnCompany>();
}