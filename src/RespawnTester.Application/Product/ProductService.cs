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

    public async Task CreateProduct(Model.Product product)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product));

        _logger.LogDebug($"CreateProduct: {JsonSerializer.Serialize(product)}");

        var entity = new Domain.Aggregates.Product.Product
        {
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            ExpirationDate = product.ExpirationDate,
            IsAvailable = product.IsAvailable,
        };

        await _productRepository.Insert(entity);

        _logger.LogInformation($"CreateProduct finish");
    }

    public async Task<IEnumerable<Model.Product>> GetProductsAll()
    {
        _logger.LogDebug($"GetProductsAll: ");

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

        _logger.LogInformation($"GetProductsAll returns: {JsonSerializer.Serialize(response)}");

        return response;
    }
    
    public async Task UpdateProduct(Model.Product product)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product));

        _logger.LogDebug($"UpdateProduct: {JsonSerializer.Serialize(product)}");

        var entity = await _productRepository.GetByID(product.Id);
        if (entity != null)
        {
            entity.Name = product.Name;
            entity.Description = product.Description;
            entity.Price = product.Price;
            entity.ExpirationDate = product.ExpirationDate;
            entity.IsAvailable = product.IsAvailable;

            await _productRepository.Update(entity);
        }
        else
            _logger.LogInformation($"UpdateProduct: Product not found");

        _logger.LogInformation($"UpdateProduct finish");
    }

    public async Task DeleteProduct(Guid productId)
    {
        _logger.LogDebug($"DeleteProduct: {productId}");

        await _productRepository.Delete(productId);

        _logger.LogInformation($"DeleteProduct finish");
    }
}


