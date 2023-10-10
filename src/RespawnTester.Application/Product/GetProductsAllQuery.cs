using MediatR;
using Entities = RespawnTester.Domain.Aggregates.Product;

namespace RespawnTester.Application.Product;

public class GetProductsAllQuery
    : IRequest<IEnumerable<Model.Product>>
{
}
