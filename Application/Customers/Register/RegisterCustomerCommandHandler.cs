using Application.Abstractions.Data;
using Application.Abstractions.Services;
using Domain.Entities.Customers;
using Domain.ValueObjects;
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
            FirstName.Create(request.FirstName).Value,
            LastName.Create(request.LastName).Value,
            Email.Create(request.Email).Value,
            Password.Create(password).Value);

        _context.Customers.Add(customer);
        await _context.SaveChangesAsync(cancellationToken);
    }

   
}
