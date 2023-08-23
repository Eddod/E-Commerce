using MediatR;

namespace Application.Customers.Register;

public sealed record RegisterCustomerCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest;
