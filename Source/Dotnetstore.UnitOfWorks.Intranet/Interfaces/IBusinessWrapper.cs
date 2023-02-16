using Dotnetstore.Intranet.Contract.Business;

namespace Dotnetstore.UnitOfWorks.Intranet.Interfaces;

public interface IBusinessWrapper
{
    IOwnCompanyWrapper OwnCompany { get; }
}