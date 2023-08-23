using Application.Abstractions.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Products.Get;

internal sealed class GetProductsQueryHandler
    : IRequestHandler<GetProductsQuery, IEnumerable<ProductResponse>>
{
    private readonly IApplicationDbContext _context;

    public GetProductsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }



    async Task<IEnumerable<ProductResponse>> IRequestHandler<GetProductsQuery, IEnumerable<ProductResponse>>.Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var productList = await _context.Products
            .Select(p => new ProductResponse(
                p.Id.Value,
                p.Name,
                p.Sku.Value,
                p.Price.Currency,
                p.Price.Amount))
            .ToListAsync();

        return productList;



    }
}
