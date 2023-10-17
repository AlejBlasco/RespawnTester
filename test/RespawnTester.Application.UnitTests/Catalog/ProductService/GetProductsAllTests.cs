using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using RespawnTester.Application.UnitTests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespawnTester.Application.UnitTests.Catalog.ProductService
{
    public class GetProductsAllTests
    {
        [Fact]
        public async Task GetAll_ShouldNotFail()
        {
            // Arrange
            var productRepository = MockProductRepositoryManager.GetMock();
            var logger = new Mock<ILogger<Product.ProductService>>();

            var service = new Product.ProductService(logger: logger.Object,
                productRepository: productRepository.Object);

            // Act
            var productList = await service.GetProductsAll();

            // Assert
            productList.Should().NotBeNullOrEmpty();
        }
    }
}
