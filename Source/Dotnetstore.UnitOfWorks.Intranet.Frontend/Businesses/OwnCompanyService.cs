using Dotnetstore.Core.Abstracts;
using Dotnetstore.Core.Interfaces;
using Dotnetstore.Core.Services;
using Dotnetstore.Shared.Business;
using System.Net;

namespace Dotnetstore.UnitOfWorks.Intranet.Frontend.Businesses;

public class OwnCompanyService : Disposable, IOwnCompanyService
{
    private IHttpService? _httpService;

    public OwnCompanyService(
        IHttpService httpService)
    {
        _httpService = httpService;
    }

    async Task<HttpResponseWrapper<OwnCompanyAddResponseDto>> IOwnCompanyService.AddAsync(OwnCompanyAddRequestDto ownCompanyAddRequestDto)
    {
        if (_httpService is null)
            return new HttpResponseWrapper<OwnCompanyAddResponseDto>(false, new OwnCompanyAddResponseDto(),
                new HttpResponseMessage(HttpStatusCode.FailedDependency));

        return await _httpService.PostAsync<OwnCompanyAddRequestDto, OwnCompanyAddResponseDto>(
            "api/Business/OwnCompanyAdd", ownCompanyAddRequestDto);
    }

    async Task<HttpResponseWrapper<List<OwnCompanyDto>>> IOwnCompanyService.GetAllAvailableAsync()
    {
        if (_httpService is null)
            return new HttpResponseWrapper<List<OwnCompanyDto>>(false, new List<OwnCompanyDto>(),
                new HttpResponseMessage(HttpStatusCode.FailedDependency));
        var result = await _httpService.GetAsync<List<OwnCompanyDto>>("api/Business/GetAllAvailableOwnCompany");
        return result;
    }

    protected override void DisposeManaged()
    {
        if (!IsDisposed)
        {
            _httpService = null;
        }

        base.DisposeManaged();
    }
}