using Dotnetstore.Domain.Business;
using Microsoft.EntityFrameworkCore;

namespace Dotnetstore.Business.Repository.EF.Contexts;

public sealed class BusinessContext : DbContext
{
    public BusinessContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<OwnCompany> OwnCompanies => Set<OwnCompany>();
}