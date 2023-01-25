namespace Dotnetstore.Shared.Business;

public class OwnCompanyAddResponseDto
{
    public bool Success { get; set; }

    public Exception? Exception { get; set; }

    public OwnCompanyDto? OwnCompany { get; set; }
}