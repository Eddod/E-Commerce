using Domain.Entities.Products;
using MediatR;

namespace Application.Products.Get;

public sealed record GetProductByIdQuery(ProductId ProductId) : IRequest<ProductResponse>;

