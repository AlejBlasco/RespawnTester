using Microsoft.Extensions.Logging;
using Moq;
using RespawnTester.Application.UnitTests.Mocks;

namespace RespawnTester.Application.UnitTests.Catalog.ProductService
{
    public class DeleteProductTests
    {
        [Fact]
        public async Task Delete_ShouldNotFail_IfParamIsGuid()
        {
            // Arrange
            var productRepository = MockProductRepositoryManager.GetMock();
            var logger = new Mock<ILogger<Product.ProductService>>();

            var service = new Product.ProductService(logger: logger.Object,
                productRepository: productRepository.Object);

            // Act
            try
            {
                await service.DeleteProduct(Guid.NewGuid());
            }
            catch (Exception ex)
            {
                // Assert
                Assert.Fail(ex.Message);
            }
        }

        [Fact]
        public async Task Delete_ShouldFail_IfParamIsGuidEmpty()
        {
            // Arrange
            var productRepository = MockProductRepositoryManager.GetMock();
            var logger = new Mock<ILogger<Product.ProductService>>();

            var service = new Product.ProductService(logger: logger.Object,
                productRepository: productRepository.Object);

            // Act & Assert
            Func<Task> act = () => service.DeleteProduct(Guid.Empty);
            await Assert.ThrowsAsync<ArgumentNullException>(act);
        }
    }
}
