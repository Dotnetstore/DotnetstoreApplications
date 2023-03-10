using Dotnetstore.Core.Database;
using Dotnetstore.Domain.Business;

namespace Dotnetstore.Intranet.Contract.Business;

public interface IOwnCompanyRepository : IGenericRepository<OwnCompany>
{
    Task<List<OwnCompany>> GetAllAsync();

    Task<List<OwnCompany>> GetAllAvailableAsync();

    Task<List<OwnCompany>> GetAllDeletedAsync();
}