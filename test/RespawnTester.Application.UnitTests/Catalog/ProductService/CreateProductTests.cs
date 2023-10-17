using Microsoft.Extensions.Logging;
using Moq;
using RespawnTester.Application.UnitTests.Mocks;

namespace RespawnTester.Application.UnitTests.Catalog.ProductService;

public class CreateProductTests
{
    [Fact]
    public async Task Create_ShouldNotFail_IfParamIsNotNull()
    {
        // Arrange
        var productRepository = MockProductRepositoryManager.GetMock();
        var logger = new Mock<ILogger<Product.ProductService>>();

        var service = new Product.ProductService(logger: logger.Object,
            productRepository: productRepository.Object);

        // Act
        try
        {
            await service.CreateProduct(new Product.Model.Product());
        }
        catch (Exception ex)
        {
            // Assert
            Assert.Fail(ex.Message);
        }
    }

    [Fact]
    public async Task Create_ShouldFail_IfParamIsNull()
    {
        // Arrange
        var productRepository = MockProductRepositoryManager.GetMock();
        var logger = new Mock<ILogger<Product.ProductService>>();

        var service = new Product.ProductService(logger: logger.Object,
            productRepository: productRepository.Object);

        // Act & Assert
        Func<Task> act = () => service.CreateProduct(null);
        await Assert.ThrowsAsync<ArgumentNullException>(act);
    }
}
