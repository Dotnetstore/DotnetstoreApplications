namespace Dotnetstore.Shared.Business;

public class OwnCompanyDto : CompanyDto
{
    public override string ToString()
    {
        var company = "";
        company += Name;

        if (!string.IsNullOrWhiteSpace(CorporateID))
        {
            company += $" ({CorporateID})";
        }

        return company;
    }
}