using Dotnetstore.Business.Service.Helpers;
using Dotnetstore.Core.Abstracts;
using Dotnetstore.Intranet.Contract.Business;
using Dotnetstore.Shared.Business;

namespace Dotnetstore.Business.Service.OwnCompanies;

public class OwnCompanyWrapper : Disposable, IOwnCompanyWrapper
{
    private IOwnCompanyService? _ownCompanyService;

    public OwnCompanyWrapper(
        IOwnCompanyService ownCompanyService)
    {
        _ownCompanyService = ownCompanyService;
    }

    async Task<OwnCompanyAddResponseDto> IOwnCompanyWrapper.AddAsync(OwnCompanyAddRequestDto ownCompanyAddRequestDto)
    {
        if (_ownCompanyService is null)
        {
            return new OwnCompanyAddResponseDto
            {
                ErrorMessage = "_businessEntityWrapper or _ownCompanyService is null.",
                OwnCompany = null,
                Success = false
            };
        }

        var ownCompany = ownCompanyAddRequestDto.ToOwnCompany();
        var (success, exception) = await _ownCompanyService.AddAsync(ownCompany, ownCompanyAddRequestDto.UserID);

        return new OwnCompanyAddResponseDto
        {
            ErrorMessage = exception?.Message,
            StackTrace = exception?.StackTrace,
            OwnCompany = ownCompany.ToOwnCompanyDto(),
            Success = success
        };
    }

    async Task<List<OwnCompanyDto>> IOwnCompanyWrapper.GetAllAsync()
    {
        if (_ownCompanyService is null)
        {
            return new List<OwnCompanyDto>();
        }

        var result = await _ownCompanyService.GetAllAsync();
        return result.ToOwnCompanyDto();
    }

    async Task<List<OwnCompanyDto>> IOwnCompanyWrapper.GetAllAvailableAsync()
    {
        if (_ownCompanyService is null)
        {
            return new List<OwnCompanyDto>();
        }

        var result = await _ownCompanyService.GetAllAvailableAsync();
        return result.ToOwnCompanyDto();
    }

    async Task<List<OwnCompanyDto>> IOwnCompanyWrapper.GetAllDeletedAsync()
    {
        if (_ownCompanyService is null)
        {
            return new List<OwnCompanyDto>();
        }

        var result = await _ownCompanyService.GetAllDeletedAsync();
        return result.ToOwnCompanyDto();
    }

    protected override void DisposeManaged()
    {
        if (!IsDisposed)
        {
            _ownCompanyService = null;
        }

        base.DisposeManaged();
    }
}