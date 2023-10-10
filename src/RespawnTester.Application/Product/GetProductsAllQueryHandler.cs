using MediatR;
using Microsoft.Extensions.Logging;
using RespawnTester.Domain.Aggregates.Product;
using System.Text.Json;

namespace RespawnTester.Application.Product;

public class GetProductsAllQueryHandler
    : IRequestHandler<GetProductsAllQuery, IEnumerable<Model.Product>>
{
    private readonly ILogger<GetProductsAllQueryHandler> _logger;
    private readonly IProductRepository _productRepository;

    public GetProductsAllQueryHandler(ILogger<GetProductsAllQueryHandler> logger, IProductRepository productRepository)
    {
        _logger = logger
            ?? throw new ArgumentNullException(nameof(logger));

        _productRepository = productRepository
            ?? throw new ArgumentNullException(nameof(productRepository));
    }

    public async Task<IEnumerable<Model.Product>> Handle(GetProductsAllQuery query, CancellationToken cancellationToken)
    {
        _logger.LogDebug($"GetProductsAllQueryHandler: {JsonSerializer.Serialize(query)}");

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
