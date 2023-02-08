using Dotnetstore.Business.Services.OwnCompanies;

namespace Dotnetstore.TestHelper.Mocks.Business;

internal static class MockIOwnCompanyRepository
{
    internal static Mock<IOwnCompanyRepository> GetMock()
    {
        var mock = new Mock<IOwnCompanyRepository>();
        var list = new List<OwnCompany>();

        mock.Setup(q => q.GetAllAsync()).Returns(() => Task.FromResult(list
            .OrderBy(q => q.Name)
            .ThenBy(q => q.CorporateID)
            .ToList()));

        mock.Setup(q => q.GetAllAvailableAsync()).Returns(() =>
            Task.FromResult(list.Where(q => !q.IsDeleted.HasValue || (q.IsDeleted.HasValue && !q.IsDeleted.Value))
                .OrderBy(q => q.Name)
                .ThenBy(q => q.CorporateID)
                .ToList()));

        mock.Setup(q => q.GetAllDeletedAsync()).Returns(() => Task.FromResult(list
            .Where(q => q.IsDeleted.HasValue && q.IsDeleted.Value)
            .OrderBy(q => q.Name)
            .ThenBy(q => q.CorporateID)
            .ToList()));

        mock.Setup(q => q.AddAsync(It.IsAny<OwnCompany>()))
            .Callback((OwnCompany entity) =>
            {
                entity.ID = Guid.NewGuid();
                list.Add(entity);
            });

        mock.Setup(q => q.DeleteAsync(It.IsAny<OwnCompany>()))
            .Callback((OwnCompany entity) => list.Remove(entity));

        mock.Setup(q => q.SaveAsync(It.IsAny<OwnCompany>()))
            .Callback((OwnCompany entity) =>
            {
                var entityToUpdate = list.FirstOrDefault(q => q.ID == entity.ID);

                if (entityToUpdate is null) return;
                list.Remove(entityToUpdate);
                list.Add(entity);
            });

        return mock;
    }
}