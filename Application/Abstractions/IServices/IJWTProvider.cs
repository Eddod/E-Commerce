using Domain.Entities.Customers;

namespace Application.Abstractions.Services;

public interface IJWTProvider
{
    string Generate(Customer customer);
}
