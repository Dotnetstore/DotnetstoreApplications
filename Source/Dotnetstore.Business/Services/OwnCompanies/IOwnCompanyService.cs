using Dotnetstore.Business.Services.Helpers;

namespace Dotnetstore.Business.Services.OwnCompanies;

public interface IOwnCompanyService : IGenericService<OwnCompany>
{
    Task<List<OwnCompany>> GetAllAsync();

    Task<List<OwnCompany>> GetAllAvailableAsync();

    Task<List<OwnCompany>> GetAllDeletedAsync();
}