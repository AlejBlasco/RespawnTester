using Microsoft.Extensions.DependencyInjection;
using RespawnTester.Application.Product;
using RespawnTester.Domain.Aggregates.Product;
using RespawnTester.Infrastructure.Repositories;
using RespawnTestes.Infrastructure.Data;
using System;
using System.Reflection;


namespace RespawnTester.Console
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection()
                .AddLogging()
                .AddTransient<IProductRepository, ProductRepository>()
                .AddTransient<IProductService, ProductService>()
                .AddDbContext<DataContext>()
                .BuildServiceProvider();

            System.Console.WriteLine("Hello, World!");

            var prodService = services.GetService<IProductService>()!;
            var pepe = await prodService.GetProductsAll();

        }
    }
}