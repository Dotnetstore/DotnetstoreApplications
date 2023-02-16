using Dotnetstore.Shared.Common;

namespace Dotnetstore.Shared.Business;

public class OwnCompanyAddResponseDto : ErrorDto
{
    public OwnCompanyDto? OwnCompany { get; set; }
}