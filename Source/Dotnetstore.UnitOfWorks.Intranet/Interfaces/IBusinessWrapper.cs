using Dotnetstore.Business.Wrappers;

namespace Dotnetstore.UnitOfWorks.Intranet.Interfaces;

public interface IBusinessWrapper
{
    IOwnCompanyWrapper OwnCompany { get; }
}