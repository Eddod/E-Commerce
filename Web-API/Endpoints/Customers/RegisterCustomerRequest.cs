namespace Web_API.Endpoints.Customers;

public record RegisterCustomerRequest(
    string FirstName,
    string LastName,
    string Email,
    string Password);
