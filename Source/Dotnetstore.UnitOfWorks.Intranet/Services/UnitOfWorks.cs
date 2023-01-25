using Dotnetstore.UnitOfWorks.Intranet.Interfaces;

namespace Dotnetstore.UnitOfWorks.Intranet.Services;

public class UnitOfWorks : IUnitOfWorks
{
    private readonly IBusinessWrapper _businessWrapper;

    public UnitOfWorks(
        IBusinessWrapper businessWrapper)
    {
        _businessWrapper = businessWrapper;
    }

    IBusinessWrapper IUnitOfWorks.Business => _businessWrapper;
}