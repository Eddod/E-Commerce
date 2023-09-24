namespace Web_API.Endpoints.Products;

public record UpdateProductRequest(
    string Name,
    string Sku,
    string Currency,
    decimal Amount);
