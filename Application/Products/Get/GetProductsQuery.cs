using MediatR;

namespace Application.Products.Get;

public record GetProductsQuery() : IRequest<IEnumerable<ProductResponse>>;

