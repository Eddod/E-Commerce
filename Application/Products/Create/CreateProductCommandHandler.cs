using Application.Abstractions.Data;
using Application.Products.Get;
using Domain.Entities.Products;
using MediatR;

namespace Application.Products.Commands;

internal sealed class CreateProductCommandHandler
    : IRequestHandler<CreateProductCommand, ProductResponse>
{
    private readonly IApplicationDbContext _context;

    public CreateProductCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product(
            new ProductId(Guid.NewGuid()),
            request.Name,
            new Money(request.Currency, request.Amount),
            Sku.Create(request.Sku)!);

        _context.Products.Add(product);

        var productResponse = new ProductResponse(product.Id.Value, product.Name, product.Sku.Value, product.Price.Currency, product.Price.Amount);

        await _context.SaveChangesAsync(cancellationToken);

        return productResponse;
    }

}
