using MediatR;
using Entities = RespawnTester.Domain.Aggregates.Product;

namespace RespawnTester.Application.Product
{
    public class GetProductByIdQuery
        : IRequest<Model.Product>
    {
        public Guid Id { get; set; }
    }
}
