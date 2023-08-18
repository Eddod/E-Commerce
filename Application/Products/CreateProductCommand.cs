using Application.Abstractions.Messaging;

namespace Application.Products;

public sealed record CreateProductCommand(string Name, decimal Price, string SkuDescription) : ICommand;

