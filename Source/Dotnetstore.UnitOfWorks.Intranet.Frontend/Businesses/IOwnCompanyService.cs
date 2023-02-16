using Dotnetstore.Core.Services;
using Dotnetstore.Shared.Business;

namespace Dotnetstore.UnitOfWorks.Intranet.Frontend.Businesses;

public interface IOwnCompanyService
{
    Task<HttpResponseWrapper<OwnCompanyAddResponseDto>> AddAsync(OwnCompanyAddRequestDto ownCompanyAddRequestDto);

    Task<HttpResponseWrapper<List<OwnCompanyDto>>> GetAllAvailableAsync();
}