using Microsoft.Extensions.Logging;
using RespawnTester.Domain.Aggregates.Product;
using System.Text.Json;

namespace RespawnTester.Application.Product;

public class ProductService : IProductService
{
    private readonly ILogger<ProductService> _logger;
    private readonly IProductRepository _productRepository;

    public ProductService(ILogger<ProductService> logger, IProductRepository productRepository)
    {
        _logger = logger
            ?? throw new ArgumentNullException(nameof(logger));

        _productRepository = productRepository
            ?? throw new ArgumentNullException(nameof(productRepository));
    }

    public async Task<IEnumerable<Model.Product>> GetProductsAll()
    {
        _logger.LogDebug($"GetProductsAllQueryHandler: ");

        var entities = await _productRepository.Get(filter: null, orderBy: null);

        var response = new List<Model.Product>();
        foreach (var entity in entities)
        {
            response.Add(new Model.Product
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price,
                ExpirationDate = entity.ExpirationDate,
                IsAvailable = entity.IsAvailable,
            });
        }

        _logger.LogInformation($"GetProductsAllQueryHandler returns: {JsonSerializer.Serialize(response)}");

        return response;
    }
}


