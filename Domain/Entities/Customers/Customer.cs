using Domain.Primitives;

namespace Domain.Entities.Customers;

public class Customer : IAuditableEntity
{
    public Customer(CustomerId id, string firstName, string lastName, string email, string password)
    {
        Id = id;
        FirstName  = firstName;
        LastName = lastName;
        Email = email;
        Password = password;

    }
    private Customer()
    {   
    }
    public CustomerId Id { get; private set; }

    public string Email { get; private set; } = string.Empty;

    public string FirstName { get; private set; } = string.Empty;

    public string LastName { get; private set; } = string.Empty;

    public string Password { get; private set; } = string.Empty;

    public DateTime CreatedOnUtC { get; set; }

    public DateTime? LastUpdatedOnUtC { get; set; }

    //public static Customer Create(
    //    Guid id,
    //    string email,
    //    string firstName,
    //    string lastName,
    //    string passWord)
    //{
    //    var customer = new Customer(
    //        id,
    //        email,
    //        firstName,
    //        lastName,
    //        passWord);
    //    return customer;
    //}

}

//Add strongly typed FirstName, LastName, Password and Email to Customer

