using Application.Abstractions.Data;
using Domain.Entities.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Products.Delete;

internal sealed class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteProductCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _context.Products
            .Where(p=>p.Id == request.ProductId)
            .FirstOrDefaultAsync();

        if (product is null)
        {
            throw new ProductNotFoundException(request.ProductId);
        }
        _context.Products.Remove(product);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
