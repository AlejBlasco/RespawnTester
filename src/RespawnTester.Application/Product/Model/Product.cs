namespace RespawnTester.Application.Product.Model;

public class Product
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public Decimal Price { get; set; } = decimal.Zero;

    public DateTime? ExpirationDate { get; set; }

    public bool IsAvailable { get; set; } = false;
}
