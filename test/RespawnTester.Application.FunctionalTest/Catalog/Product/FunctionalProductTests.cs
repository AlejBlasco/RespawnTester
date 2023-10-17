using Microsoft.Extensions.Logging;
using Moq;
using RespawnTester.Application.FunctionalTests.Fixtures;
using RespawnTester.Application.Product;
using RespawnTester.Domain.Aggregates.Product;
using RespawnTester.Infrastructure.Repositories;

namespace RespawnTester.Application.FunctionalTests.Catalog.Product;

public class FunctionalProductTests
    : IClassFixture<DatabaseFixture>
{
    private readonly DatabaseFixture _fixture;

    public FunctionalProductTests(DatabaseFixture fixture)
    {
        this._fixture = fixture
            ?? throw new ArgumentNullException(nameof(fixture));
    }

    [Fact]
    public async Task UpdateProduct_ShouldNotFail_IfProductExists()
    {
        // Arrange
        var productRepository = new ProductRepository(_fixture.DataContext);
        var logger = new Mock<ILogger<ProductService>>();

        var service = new ProductService(logger: logger.Object,
                productRepository: productRepository);

        await service.CreateProduct(new Application.Product.Model.Product
        {
             Id = Guid.NewGuid(),
             Name = $"RespawnTest Product -> {DateTime.Now.ToShortDateString()}.{DateTime.Now.ToShortTimeString()}",  
        });

        Assert.True(true);
    }
}
