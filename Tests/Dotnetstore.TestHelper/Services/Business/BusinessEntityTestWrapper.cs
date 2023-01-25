using Dotnetstore.TestHelper.Mocks.Business;

namespace Dotnetstore.TestHelper.Services.Business;

public class BusinessEntityTestWrapper : IBusinessEntityTestWrapper
{
    private readonly IBusinessEntityRepository _businessEntityRepository;
    private readonly IBusinessEntityService _businessEntityService;
    private readonly IBusinessEntityWrapper _businessEntityWrapper;

    IBusinessEntityRepository IBusinessEntityTestWrapper.Repository => _businessEntityRepository;

    IBusinessEntityService IBusinessEntityTestWrapper.Service => _businessEntityService;

    IBusinessEntityWrapper IBusinessEntityTestWrapper.Wrapper => _businessEntityWrapper;

    public BusinessEntityTestWrapper()
    {
        _businessEntityRepository = MockIBusinessEntityRepository.GetMock().Object;
        _businessEntityService = new BusinessEntityService(_businessEntityRepository);
        _businessEntityWrapper = new BusinessEntityWrapper(_businessEntityService);
    }
}