using Application.Customers.Register;
using Carter;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Endpoints.Customers;

public class CustomersModule : ICarterModule
{
    public CustomersModule() 
        : base()
    {
        
    }
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("customers", async ([FromBody] RegisterCustomerRequest request, ISender sender) =>
        {
            var command = request.Adapt<RegisterCustomerCommand>();
            await sender.Send(command);

            return Results.Ok();
        });
    }
}
