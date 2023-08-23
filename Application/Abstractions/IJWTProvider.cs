using Domain.Entities.Customers;

namespace Application.Abstractions;

public interface IJWTProvider
{
    string Generate(Customer customer);
}
