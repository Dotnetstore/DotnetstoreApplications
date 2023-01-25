namespace Dotnetstore.TestHelper.Services.Business;

public class BusinessService : IBusinessService
{
    private readonly IBusinessEntityTestWrapper _businessEntityTestWrapper;
    private readonly IOwnCompanyTestWrapper _ownCompanyTestWrapper;

    IBusinessEntityTestWrapper IBusinessService.BusinessEntity => _businessEntityTestWrapper;

    IOwnCompanyTestWrapper IBusinessService.OwnCompany => _ownCompanyTestWrapper;

    public BusinessService()
    {
        _businessEntityTestWrapper = new BusinessEntityTestWrapper();
        _ownCompanyTestWrapper = new OwnCompanyTestWrapper();
    }
}