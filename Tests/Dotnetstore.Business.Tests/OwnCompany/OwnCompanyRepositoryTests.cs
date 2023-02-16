namespace Dotnetstore.Business.Tests.OwnCompany;

public class OwnCompanyRepositoryTests
{
    private ITestHelperService? _testHelperService;

    [TestCase("Dotnetstore", "My own company", "710520-1433")]
    public async Task TestAddOwnCompany(string name, string description, string organizationNumber)
    {
        _testHelperService = new TestHelperService();

        await GetOwnCompanyAsync(0);
        await AddOwnCompanyAsync(name, description, organizationNumber);
        await GetOwnCompanyAsync(1);
    }

    private async Task AddOwnCompanyAsync(string name, string description, string organizationNumber)
    {
        if (_testHelperService is null)
            return;

        var ownCompanyToAdd = new Domain.Business.OwnCompany
        {
            Name = name,
            Description = description,
            CorporateID = organizationNumber,
            ID = Guid.NewGuid()
        };

        await _testHelperService.Business.OwnCompany.Repository.AddAsync(ownCompanyToAdd);
    }

    private async Task AddMixedCompaniesAsync()
    {
        if (_testHelperService is null)
            return;

        var ownCompanyToAdd = new Domain.Business.OwnCompany
        {
            Name = "Dotnetstore",
            Description = "My own company",
            CorporateID = "710520-1433",
            ID = Guid.NewGuid()
        };

        await _testHelperService.Business.OwnCompany.Repository.AddAsync(ownCompanyToAdd);

        ownCompanyToAdd = new Domain.Business.OwnCompany
        {
            Name = "Dotnetstore",
            Description = "My own company",
            CorporateID = "710520-1433",
            ID = Guid.NewGuid(),
            IsDeleted = true
        };

        await _testHelperService.Business.OwnCompany.Repository.AddAsync(ownCompanyToAdd);

        ownCompanyToAdd = new Domain.Business.OwnCompany
        {
            Name = "Dotnetstore",
            Description = "My own company",
            CorporateID = "710520-1433",
            ID = Guid.NewGuid()
        };

        await _testHelperService.Business.OwnCompany.Repository.AddAsync(ownCompanyToAdd);
    }

    private async Task GetOwnCompanyAsync(int expectedQuantity)
    {
        if (_testHelperService is null)
            return;

        var list = await _testHelperService.Business.OwnCompany.Repository.GetAllAsync();

        Assert.That(list, Is.Not.Null);
        Assert.That(list, Is.InstanceOf<List<Domain.Business.OwnCompany>>());
        Assert.That(list, Has.Count.EqualTo(expectedQuantity));
    }

    private async Task GetOwnCompanyDeletedAsync(int expectedQuantity)
    {
        if (_testHelperService is null)
            return;

        var list = await _testHelperService.Business.OwnCompany.Repository.GetAllDeletedAsync();

        Assert.That(list, Is.Not.Null);
        Assert.That(list, Is.InstanceOf<List<Domain.Business.OwnCompany>>());
        Assert.That(list, Has.Count.EqualTo(expectedQuantity));
    }

    private async Task GetOwnCompanyAvailableAsync(int expectedQuantity)
    {
        if (_testHelperService is null)
            return;

        var list = await _testHelperService.Business.OwnCompany.Repository.GetAllAvailableAsync();

        Assert.That(list, Is.Not.Null);
        Assert.That(list, Is.InstanceOf<List<Domain.Business.OwnCompany>>());
        Assert.That(list, Has.Count.EqualTo(expectedQuantity));
    }

    [Test]
    public async Task TestGetAll()
    {
        _testHelperService = new TestHelperService();

        await GetOwnCompanyAsync(0);
        await AddMixedCompaniesAsync();
        await GetOwnCompanyAsync(3);
    }

    [Test]
    public async Task TestGetAllDeleted()
    {
        _testHelperService = new TestHelperService();

        await GetOwnCompanyDeletedAsync(0);
        await AddMixedCompaniesAsync();
        await GetOwnCompanyDeletedAsync(1);
    }

    [Test]
    public async Task TestGetAllAvailable()
    {
        _testHelperService = new TestHelperService();

        await GetOwnCompanyAvailableAsync(0);
        await AddMixedCompaniesAsync();
        await GetOwnCompanyAvailableAsync(2);
    }
}