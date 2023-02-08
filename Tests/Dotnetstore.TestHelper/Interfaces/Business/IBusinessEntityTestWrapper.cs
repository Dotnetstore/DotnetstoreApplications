using Dotnetstore.Business.Services.BusinessEntities;

namespace Dotnetstore.TestHelper.Interfaces.Business;

public interface IBusinessEntityTestWrapper
{
    IBusinessEntityRepository Repository { get; }

    IBusinessEntityService Service { get; }

    IBusinessEntityWrapper Wrapper { get; }
}