namespace Web_API.Endpoints.Products;

public sealed record CreateProductRequest(string Name, decimal Price, string SkuDescription);


