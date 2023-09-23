using Application.Abstractions.Data;
using Application.Abstractions.IServices;
using Application.Abstractions.Messaging;
using Application.Abstractions.Services;
using Domain.Entities.Customers;
using Domain.Errors;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace Application.Customers.Login;

internal sealed class LoginCommandHandler 
    : ICommandHandler<LoginCommand, string>
{
    private readonly IPasswordService _passwordService;
    private readonly IJwtProviderService _jwtProvider;
    private readonly IApplicationDbContext _context;

    public LoginCommandHandler(
        IPasswordService passwordService,
        IApplicationDbContext context,
        IJwtProviderService jwtProvider)
    {
        _passwordService = passwordService;
        _context = context;
        _jwtProvider = jwtProvider;
    }

    public async Task<Result<string>> Handle(
        LoginCommand request,
        CancellationToken cancellationToken)
    {

        var allCustomers = await _context.Customers.ToListAsync();
        Customer? customer = allCustomers.Where(e=>e.Email.Value == request.Email).SingleOrDefault();

        if (customer is null)
        {
            return Result.Failure<string>(
                DomainErrors.Customer.InvalidCredentials);
        }

        bool passWordIsValid = _passwordService.VerifyPassword(
            request.Password,
            customer.Password.Value);

        if (!passWordIsValid)
        {
            return Result.Failure<string>(
                DomainErrors.Password.InvalidCredentials);
        }

        string token = _jwtProvider.Generate(customer);

        return token;
    }


}
