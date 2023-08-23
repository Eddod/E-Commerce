using Application.Abstractions.Data;
using Domain.Entities.Customers;
using MediatR;

namespace Application.Customers.Register;

internal sealed class RegisterCustomerCommandHandler : 
    IRequestHandler<RegisterCustomerCommand>
{
    private readonly IApplicationDbContext _context;

    public RegisterCustomerCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(RegisterCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new Customer(
            new CustomerId(Guid.NewGuid()),
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        _context.Customers.Add(customer);
        await _context.SaveChangesAsync(cancellationToken);
    }

   
}
