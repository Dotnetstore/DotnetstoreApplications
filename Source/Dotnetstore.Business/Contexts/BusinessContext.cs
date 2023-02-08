using Microsoft.EntityFrameworkCore;

namespace Dotnetstore.Business.Contexts;

public sealed class BusinessContext : DbContext
{
    public BusinessContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<BusinessEntity> BusinessEntities => Set<BusinessEntity>();

    public DbSet<OwnCompany> OwnCompanies => Set<OwnCompany>();
}