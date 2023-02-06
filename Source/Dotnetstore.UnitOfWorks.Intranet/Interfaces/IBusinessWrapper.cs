using Dotnetstore.Business.Services.OwnCompanies;

namespace Dotnetstore.UnitOfWorks.Intranet.Interfaces;

public interface IBusinessWrapper
{
    IOwnCompanyWrapper OwnCompany { get; }
}