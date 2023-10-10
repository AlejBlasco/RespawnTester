using Microsoft.EntityFrameworkCore;
using RespawnTester.Domain.Aggregates.Product;

namespace RespawnTestes.Infrastructure.Data;

public class DataContext
    : DbContext
{
    public DataContext() 
    {
    }

    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Server=(local);Database=respawntester-db;Trusted_Connection=True;TrustServerCertificate=true;");
    }

    public DbSet<Product> Products { get; set; }
}
