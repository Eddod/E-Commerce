using Domain.Primitives;
using Domain.ValueObjects;

namespace Domain.Entities.Customers;

public class Customer : IAuditableEntity
{
    public Customer(CustomerId id, FirstName firstName, LastName lastName, Email email, Password password)
    {
        Id = id;
        FirstName  = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        CreatedOnUtC = DateTime.UtcNow;
    }
    private Customer()
    {   
    }
    public CustomerId Id { get; private set; }

    public Email Email { get; private set; } 

    public FirstName FirstName { get; private set; } 

    public LastName LastName { get; private set; } 

    public Password Password { get; private set; } 

    public DateTime CreatedOnUtC { get; set; }

    public DateTime? LastUpdatedOnUtC { get; set; }

}

