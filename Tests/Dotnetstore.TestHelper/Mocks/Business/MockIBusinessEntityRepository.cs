using Dotnetstore.Business.Services.BusinessEntities;

namespace Dotnetstore.TestHelper.Mocks.Business;

internal static class MockIBusinessEntityRepository
{
    internal static Mock<IBusinessEntityRepository> GetMock()
    {
        var mock = new Mock<IBusinessEntityRepository>();
        var list = new List<BusinessEntity>();

        mock.Setup(q => q.GetAllAsync()).Returns(() => Task.FromResult(list));

        mock.Setup(q => q.AddAsync(It.IsAny<BusinessEntity>()))
            .Callback((BusinessEntity entity) =>
            {
                entity.ID = Guid.NewGuid();
                list.Add(entity);
            });

        mock.Setup(q => q.DeleteAsync(It.IsAny<BusinessEntity>()))
            .Callback((BusinessEntity entity) => list.Remove(entity));

        mock.Setup(q => q.SaveAsync(It.IsAny<BusinessEntity>()))
            .Callback((BusinessEntity entity) =>
            {
                var entityToUpdate = list.FirstOrDefault(q => q.ID == entity.ID);

                if (entityToUpdate is null) return;
                list.Remove(entityToUpdate);
                list.Add(entity);
            });

        return mock;
    }
}