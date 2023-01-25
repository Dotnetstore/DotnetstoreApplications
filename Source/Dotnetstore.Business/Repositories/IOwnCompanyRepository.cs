namespace Dotnetstore.Business.Repositories;

public interface IOwnCompanyRepository : IGenericRepository<OwnCompany>
{
    Task<List<OwnCompany>> GetAllAsync();

    Task<List<OwnCompany>> GetAllAvailableAsync();

    Task<List<OwnCompany>> GetAllDeletedAsync();
}