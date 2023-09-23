using Domain.Entities.Customers;

namespace Application.Abstractions.IServices;

public interface IJwtProviderService
{
    public string Generate(Customer customer);
}
