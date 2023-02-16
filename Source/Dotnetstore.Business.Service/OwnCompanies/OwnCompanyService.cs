using Dotnetstore.Core.Database;
using Dotnetstore.Domain.Business;
using Dotnetstore.Intranet.Contract.Business;

namespace Dotnetstore.Business.Service.OwnCompanies;

public sealed class OwnCompanyService : GenericService<OwnCompany>, IOwnCompanyService
{
    private IOwnCompanyRepository? _ownCompanyRepository;

    public OwnCompanyService(IOwnCompanyRepository ownCompanyRepository) : base(ownCompanyRepository)
    {
        _ownCompanyRepository = ownCompanyRepository;
    }

    async Task<List<OwnCompany>> IOwnCompanyService.GetAllAsync()
    {
        if (_ownCompanyRepository is null)
        {
            return new List<OwnCompany>();
        }

        return await _ownCompanyRepository.GetAllAsync();
    }

    async Task<List<OwnCompany>> IOwnCompanyService.GetAllAvailableAsync()
    {
        if (_ownCompanyRepository is null)
        {
            return new List<OwnCompany>();
        }

        return await _ownCompanyRepository.GetAllAvailableAsync();
    }

    async Task<List<OwnCompany>> IOwnCompanyService.GetAllDeletedAsync()
    {
        if (_ownCompanyRepository is null)
        {
            return new List<OwnCompany>();
        }

        return await _ownCompanyRepository.GetAllDeletedAsync();
    }

    protected override void DisposeManaged()
    {
        if (!IsDisposed)
        {
            _ownCompanyRepository = null;
        }

        base.DisposeManaged();
    }
}