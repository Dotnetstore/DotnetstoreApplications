using Dotnetstore.Business.Services.OwnCompanies;
using Dotnetstore.TestHelper.Mocks.Business;

namespace Dotnetstore.TestHelper.Services.Business;

public class OwnCompanyTestWrapper : IOwnCompanyTestWrapper
{
    private readonly IOwnCompanyRepository _repository;
    private readonly IOwnCompanyService _service;
    private readonly IOwnCompanyWrapper _wrapper;

    public OwnCompanyTestWrapper()
    {
        _repository = MockIOwnCompanyRepository.GetMock().Object;
        _service = new OwnCompanyService(_repository);
        _wrapper = new OwnCompanyWrapper(_service);
    }

    IOwnCompanyRepository IOwnCompanyTestWrapper.Repository => _repository;

    IOwnCompanyService IOwnCompanyTestWrapper.Service => _service;

    IOwnCompanyWrapper IOwnCompanyTestWrapper.Wrapper => _wrapper;
}