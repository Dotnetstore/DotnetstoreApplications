using Dotnetstore.Intranet.Contract.Business;

namespace Dotnetstore.TestHelper.Interfaces.Business;

public interface IOwnCompanyTestWrapper
{
    IOwnCompanyRepository Repository { get; }

    IOwnCompanyService Service { get; }

    IOwnCompanyWrapper Wrapper { get; }
}