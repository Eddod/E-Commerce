namespace Web_API.Endpoints.Products;

public record CreateProductRequest(
    string Name,
    string Sku,
    string Currency,
    decimal Amount);


