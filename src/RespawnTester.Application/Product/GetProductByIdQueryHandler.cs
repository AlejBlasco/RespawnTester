using MediatR;
using Microsoft.Extensions.Logging;
using RespawnTester.Domain.Aggregates.Product;
using System.Text.Json;

namespace RespawnTester.Application.Product;

public class GetProductByIdQueryHandler
    : IRequestHandler<GetProductByIdQuery, Model.Product>
{
    private readonly ILogger<GetProductsAllQueryHandler> _logger;
    private readonly IProductRepository _productRepository;

    public GetProductByIdQueryHandler(ILogger<GetProductsAllQueryHandler> logger, IProductRepository productRepository)
    {
        _logger = logger
            ?? throw new ArgumentNullException(nameof(logger));

        _productRepository = productRepository
            ?? throw new ArgumentNullException(nameof(productRepository));
    }

    public async Task<Model.Product> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        _logger.LogDebug($"GetProductByIdQueryHandler: {JsonSerializer.Serialize(query)}");

        var entity = await _productRepository.GetByID(query.Id);
        var response = new Model.Product
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Price = entity.Price,
            ExpirationDate = entity.ExpirationDate,
            IsAvailable = entity.IsAvailable,
        };

        _logger.LogInformation($"GetProductByIdQueryHandler returns: {JsonSerializer.Serialize(response)}");

        return response;
    }
}
