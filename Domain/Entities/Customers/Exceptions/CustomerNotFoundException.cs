namespace Domain.Entities.Customers.Exceptions;

public class CustomerNotFoundException : Exception
{
    public CustomerNotFoundException(CustomerId id)
        : base($"The customer with the ID = {id.Value} was not found")
    {
        
    }
}


