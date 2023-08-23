using Application.Abstractions.Data;
using Domain.Entities.Products;
using MediatR;

namespace Application.Products.Commands;

internal sealed class CreateProductCommandHandler
    : IRequestHandler<CreateProductCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateProductCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product(
            new ProductId(Guid.NewGuid()),
            request.Name,
            new Money(request.Currency, request.Amount),
            Sku.Create(request.Sku)!);

        _context.Products.Add(product);
        await _context.SaveChangesAsync(cancellationToken);

    }
}
