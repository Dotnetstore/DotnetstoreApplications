namespace Dotnetstore.TestHelper.Services.Business;

public class BusinessService : IBusinessService
{
    private readonly IOwnCompanyTestWrapper _ownCompanyTestWrapper;

    IOwnCompanyTestWrapper IBusinessService.OwnCompany => _ownCompanyTestWrapper;

    public BusinessService()
    {
        _ownCompanyTestWrapper = new OwnCompanyTestWrapper();
    }
}