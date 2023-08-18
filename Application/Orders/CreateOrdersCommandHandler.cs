using Application.Abstractions.Data;
using Domain.Entities.Customers;
using Domain.Entities.Orders;
using MediatR;

namespace Application.Orders;

internal sealed class CreateOrdersCommandHandler : IRequestHandler<CreateOrdersCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateOrdersCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(CreateOrdersCommand request, CancellationToken cancellationToken)
    {
        var customer = await _context.Customers.FindAsync(
            new CustomerId(request.CusomerId));

        if (customer is null)
        {
            return;
        }
        var order = Order.Create(customer.Id);   

        _context.Orders.Add(order);

        await _context.SaveChangesAsync(cancellationToken);
    }
}
