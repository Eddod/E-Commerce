using Application.Abstractions.Data;
using Domain.Entities.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Products.Get;

public sealed class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductResponse>
{
    private readonly IApplicationDbContext _context;

    public GetProductByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ProductResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _context.Products
            .Where(p => p.Id == request.ProductId)
            .Select(p => new ProductResponse(
                p.Id.Value,
                p.Name,
                p.Sku.Value,
                p.Price.Currency,
                p.Price.Amount))
            .FirstOrDefaultAsync(cancellationToken);

        if (product is null)
        {
            throw new ProductNotFoundException(request.ProductId);
        }

        return product;


    }
}

