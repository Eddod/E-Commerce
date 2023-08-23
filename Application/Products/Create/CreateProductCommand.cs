using MediatR;

namespace Application.Products.Commands;

public sealed record CreateProductCommand(
    string Name,
    string Sku,
    string Currency,
    decimal Amount) : IRequest;

