using Dotnetstore.Intranet.Contract.Business;
using Dotnetstore.UnitOfWorks.Intranet.Interfaces;

namespace Dotnetstore.UnitOfWorks.Intranet.Services;

public sealed class BusinessWrapper : IBusinessWrapper
{
    private readonly IOwnCompanyWrapper _ownCompanyWrapper;

    public BusinessWrapper(
        IOwnCompanyWrapper ownCompanyWrapper)
    {
        _ownCompanyWrapper = ownCompanyWrapper;
    }

    IOwnCompanyWrapper IBusinessWrapper.OwnCompany => _ownCompanyWrapper;
}