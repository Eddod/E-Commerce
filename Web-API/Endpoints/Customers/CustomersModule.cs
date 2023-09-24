using Application.Customers.Login;
using Application.Customers.Register;
using Carter;
using Domain.Errors;
using Domain.Shared;
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

        app.MapPost("customers/login", async (
            [FromBody] LoginRequest request,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            var command = request.Adapt<LoginCommand>();
            Result<string> tokenResult = await sender.Send(command, cancellationToken);

            if (tokenResult.IsFailure)
            {
                return Results.BadRequest(DomainErrors.Password.InvalidCredentials);
            }
            return Results.Ok(tokenResult.Value);

        });
    }
}
