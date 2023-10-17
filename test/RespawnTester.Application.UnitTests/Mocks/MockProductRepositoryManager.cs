using Moq;
using RespawnTester.Domain.Aggregates.Product;

namespace RespawnTester.Application.UnitTests.Mocks;

public static class MockProductRepositoryManager
{
    public static Mock<IProductRepository> GetMock(MockBehavior mockBehavior = MockBehavior.Strict)
    {
        var mock = new Mock<IProductRepository>(mockBehavior);

        mock
            .Setup(x => x.GetByID(It.IsAny<Guid>()))
            .Returns(Task.FromResult(new Domain.Aggregates.Product.Product()));

        mock
            .Setup(x => x.Get(null, null))
            .Returns(Task.FromResult(new List<Domain.Aggregates.Product.Product>()
            {
                new Domain.Aggregates.Product.Product(),
                new Domain.Aggregates.Product.Product()
            }.AsEnumerable()));

        mock
            .Setup(x => x.Insert(It.IsAny<Domain.Aggregates.Product.Product>()))
            .Returns(Task.CompletedTask);

        mock
            .Setup(x => x.Update(It.IsAny<Domain.Aggregates.Product.Product>()))
            .Returns(Task.CompletedTask);

        mock
            .Setup(x => x.Delete(It.IsAny<Guid>()))
            .Returns(Task.CompletedTask);

        return mock;
    }

}
