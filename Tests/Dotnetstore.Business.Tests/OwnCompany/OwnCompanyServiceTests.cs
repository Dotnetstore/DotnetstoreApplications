namespace Dotnetstore.Business.Tests.OwnCompany;

public class OwnCompanyServiceTests
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

    [Test]
    public async Task TestGetAll()
    {
        _testHelperService = new TestHelperService();

        await GetOwnCompanyAsync(0);
        await AddMixedCompaniesAsync();
        await GetOwnCompanyAsync(3);
    }

    [Test]
    public async Task TestGetAllAvailable()
    {
        _testHelperService = new TestHelperService();

        await GetOwnCompanyAvailableAsync(0);
        await AddMixedCompaniesAsync();
        await GetOwnCompanyAvailableAsync(2);
    }

    [Test]
    public async Task TestGetAllDeleted()
    {
        _testHelperService = new TestHelperService();

        await GetOwnCompanyDeletedAsync(0);
        await AddMixedCompaniesAsync();
        await GetOwnCompanyDeletedAsync(1);
    }

    private async Task AddMixedCompaniesAsync()
    {
        if (_testHelperService is null)
            return;

        Guid? userID = null;

        var ownCompanyToAdd = new Models.OwnCompany
        {
            Name = "Dotnetstore",
            Description = "My own company",
            CorporateID = "710520-1433"
        };

        await _testHelperService.Business.OwnCompany.Service.AddAsync(ownCompanyToAdd, userID);

        ownCompanyToAdd = new Models.OwnCompany
        {
            Name = "Dotnetstore",
            Description = "My own company",
            CorporateID = "710520-1433",
            IsDeleted = true
        };

        await _testHelperService.Business.OwnCompany.Service.AddAsync(ownCompanyToAdd, userID);

        ownCompanyToAdd = new Models.OwnCompany
        {
            Name = "Dotnetstore",
            Description = "My own company",
            CorporateID = "710520-1433"
        };

        await _testHelperService.Business.OwnCompany.Service.AddAsync(ownCompanyToAdd, userID);
    }

    private async Task AddOwnCompanyAsync(string name, string description, string organizationNumber)
    {
        if (_testHelperService is null)
            return;

        var ownCompanyToAdd = new Models.OwnCompany
        {
            Name = name,
            Description = description,
            CorporateID = organizationNumber
        };

        await _testHelperService.Business.OwnCompany.Service.AddAsync(ownCompanyToAdd, null);
    }
    private async Task GetOwnCompanyAsync(int expectedQuantity)
    {
        if (_testHelperService is null)
            return;

        var list = await _testHelperService.Business.OwnCompany.Service.GetAllAsync();

        Assert.That(list, Is.Not.Null);
        Assert.That(list, Is.InstanceOf<List<Models.OwnCompany>>());
        Assert.That(list, Has.Count.EqualTo(expectedQuantity));
    }

    private async Task GetOwnCompanyAvailableAsync(int expectedQuantity)
    {
        if (_testHelperService is null)
            return;

        var list = await _testHelperService.Business.OwnCompany.Service.GetAllAvailableAsync();

        Assert.That(list, Is.Not.Null);
        Assert.That(list, Is.InstanceOf<List<Models.OwnCompany>>());
        Assert.That(list, Has.Count.EqualTo(expectedQuantity));
    }

    private async Task GetOwnCompanyDeletedAsync(int expectedQuantity)
    {
        if (_testHelperService is null)
            return;

        var list = await _testHelperService.Business.OwnCompany.Service.GetAllDeletedAsync();

        Assert.That(list, Is.Not.Null);
        Assert.That(list, Is.InstanceOf<List<Models.OwnCompany>>());
        Assert.That(list, Has.Count.EqualTo(expectedQuantity));
    }
}