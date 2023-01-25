namespace Dotnetstore.Business.Tests.BusinessEntity;

public class BusinessEntityServiceTests
{
    private ITestHelperService? _testHelperService;

    [Test]
    public async Task TestAddBusinessEntity()
    {
        _testHelperService = new TestHelperService();

        await GetBusinessEntityAsync(0);
        await AddBusinessEntityAsync();
        await GetBusinessEntityAsync(1);
    }

    private async Task AddBusinessEntityAsync()
    {
        if (_testHelperService is null)
            return;

        var businessEntityToAdd = new Models.BusinessEntity();
        await _testHelperService.Business.BusinessEntity.Service.AddAsync(businessEntityToAdd, null);
    }

    private async Task GetBusinessEntityAsync(int expectedQuantity)
    {
        if (_testHelperService is null)
            return;

        var list = await _testHelperService.Business.BusinessEntity.Service.GetAllAsync();

        Assert.That(list, Is.Not.Null);
        Assert.That(list, Is.InstanceOf<List<Models.BusinessEntity>>());
        Assert.That(list, Has.Count.EqualTo(expectedQuantity));
    }
}