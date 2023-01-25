using Dotnetstore.TestHelper.Interfaces;
using Dotnetstore.TestHelper.Services.Business;

namespace Dotnetstore.TestHelper.Services;

public class TestHelperService : ITestHelperService
{
    private readonly IBusinessService _businessService;

    IBusinessService ITestHelperService.Business => _businessService;

    public TestHelperService()
    {
        _businessService = new BusinessService();
    }
}