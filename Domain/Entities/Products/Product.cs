namespace Domain.Entities.Products;

public class Product
{
    public ProductId Id { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public Money Price { get; private set; }

    public Sku Sku { get; private set; }

    public static Product? Create(string name, decimal price, string skuValue)
    {
        var product = new Product()
        {
            Id = new ProductId(Guid.NewGuid()),
            Name = name,
            Price = new Money("SEK", price),
            Sku = Sku.Create(skuValue),
        };
        return product;
    }
}
