namespace Dotnetstore.TestHelper.Interfaces.Business;

public interface IBusinessService
{
    IBusinessEntityTestWrapper BusinessEntity { get; }

    IOwnCompanyTestWrapper OwnCompany { get; }
}