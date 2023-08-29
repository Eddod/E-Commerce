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
        app.MapPost("customers/register", async (
            [FromBody] RegisterCustomerCommand request,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
           await sender.Send(request, cancellationToken);

            return Results.Ok();
        });
    }
}
