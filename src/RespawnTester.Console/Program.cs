using Microsoft.Extensions.DependencyInjection;
using RespawnTester.Application.Product;
using RespawnTester.Application.Product.Model;
using RespawnTester.Domain.Aggregates.Product;
using RespawnTester.Infrastructure.Repositories;
using RespawnTestes.Infrastructure.Data;
using System.Text.Json;

namespace RespawnTester.Console
{
    internal static class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection()
                .AddLogging()
                .AddTransient<IProductRepository, ProductRepository>()
                .AddTransient<IProductService, ProductService>()
                .AddDbContext<DataContext>()
                .BuildServiceProvider();

            System.Console.WriteLine("All systems nominal");

            var prodService = services.GetService<IProductService>()!;
            var products = await prodService.GetProductsAll();

            System.Console.WriteLine(JsonSerializer.Serialize(products));
        }
    }
}