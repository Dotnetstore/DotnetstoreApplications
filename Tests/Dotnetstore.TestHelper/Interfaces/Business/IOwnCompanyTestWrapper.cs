using Dotnetstore.Business.Services.OwnCompanies;

namespace Dotnetstore.TestHelper.Interfaces.Business;

public interface IOwnCompanyTestWrapper
{
    IOwnCompanyRepository Repository { get; }

    IOwnCompanyService Service { get; }

    IOwnCompanyWrapper Wrapper { get; }
}