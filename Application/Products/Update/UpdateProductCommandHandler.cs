using Application.Abstractions.Data;
using Domain.Entities.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Products.Update;

internal sealed class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateProductCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _context.Products
            .SingleOrDefaultAsync(p => p.Id == request.ProductId);
        if (product is null)
        {
            throw new ProductNotFoundException(request.ProductId);
        }

        product.Update(
            request.Name,
            new Money(
                request.Currency,
                request.Amount),
            Sku.Create(request.Sku)!);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
