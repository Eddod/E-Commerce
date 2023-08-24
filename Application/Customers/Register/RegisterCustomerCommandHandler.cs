using Application.Abstractions.Data;
using Application.Abstractions.Services;
using Domain.Entities.Customers;
using MediatR;

namespace Application.Customers.Register;

internal sealed class RegisterCustomerCommandHandler : 
    IRequestHandler<RegisterCustomerCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IPasswordService _passwordService;
    public RegisterCustomerCommandHandler(IApplicationDbContext context, IPasswordService passwordService)
    {
        _context = context;
        _passwordService = passwordService;
    }

    public async Task Handle(RegisterCustomerCommand request, CancellationToken cancellationToken)
    {
        var password = _passwordService.HashPassword(request.Password);
        var customer = new Customer(
            new CustomerId(Guid.NewGuid()),
            request.FirstName,
            request.LastName,
            request.Email,
            password);

        _context.Customers.Add(customer);
        await _context.SaveChangesAsync(cancellationToken);
    }

   
}
