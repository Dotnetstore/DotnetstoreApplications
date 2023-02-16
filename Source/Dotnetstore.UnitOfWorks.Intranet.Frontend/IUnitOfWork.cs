using Dotnetstore.UnitOfWorks.Intranet.Frontend.Businesses;

namespace Dotnetstore.UnitOfWorks.Intranet.Frontend;

public interface IUnitOfWork
{
    IBusinessService? Business { get; }
}