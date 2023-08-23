namespace Domain.Entities.Products;

public class ProductNotFoundException : Exception
{
    public ProductNotFoundException(ProductId id)
        : base($"The product with the ID = {id.Value} was not found")
    {
        
    }
}

