using RespawnTester.Domain.Aggregates.Product;
using RespawnTestes.Infrastructure.Data;

namespace RespawnTester.Infrastructure.Repositories;

public class ProductRepository
    : Repository<Product>, IProductRepository
{
    public ProductRepository(DataContext context) : base(context)
    {
    }
}
