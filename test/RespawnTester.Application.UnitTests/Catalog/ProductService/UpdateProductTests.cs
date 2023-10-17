using Microsoft.Extensions.Logging;
using Moq;
using RespawnTester.Application.UnitTests.Mocks;

namespace RespawnTester.Application.UnitTests.Catalog.ProductService;

public class UpdateProductTests
{
    [Fact]
    public async Task Update_ShouldNotFail_IfParamIsNotNull()
    {
        // Arrange
        var productRepository = MockProductRepositoryManager.GetMock();
        var logger = new Mock<ILogger<Product.ProductService>>();

        var service = new Product.ProductService(logger: logger.Object,
            productRepository: productRepository.Object);

        // Act
        try
        {
            await service.UpdateProduct(new Product.Model.Product());
        }
        catch (Exception ex)
        {
            // Assert
            Assert.Fail(ex.Message);
        }
    }

    [Fact]
    public async Task Update_ShouldFail_IfParamIsNull()
    {
        // Arrange
        var productRepository = MockProductRepositoryManager.GetMock();
        var logger = new Mock<ILogger<Product.ProductService>>();

        var service = new Product.ProductService(logger: logger.Object,
            productRepository: productRepository.Object);

        // Act & Assert
        Func<Task> act = () => service.UpdateProduct(null);
        await Assert.ThrowsAsync<ArgumentNullException>(act);
    }
}
