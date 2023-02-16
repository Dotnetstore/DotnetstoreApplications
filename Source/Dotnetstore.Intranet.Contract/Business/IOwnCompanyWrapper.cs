using Dotnetstore.Shared.Business;

namespace Dotnetstore.Intranet.Contract.Business;

public interface IOwnCompanyWrapper
{
    Task<OwnCompanyAddResponseDto> AddAsync(OwnCompanyAddRequestDto ownCompanyAddRequestDto);

    Task<List<OwnCompanyDto>> GetAllAsync();

    Task<List<OwnCompanyDto>> GetAllDeletedAsync();

    Task<List<OwnCompanyDto>> GetAllAvailableAsync();
}