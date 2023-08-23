using Application.Products.Commands;
using Application.Products.Delete;
using Application.Products.Get;
using Application.Products.Update;
using Carter;
using Domain.Entities.Products;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Endpoints.Products;

public class ProductsModule : ICarterModule
{
    public ProductsModule()
        : base()
    {

    }
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("products", async (ISender sender) =>
        {
            var query = await sender.Send(new GetProductsQuery());
            return query;
        });
        app.MapGet("products/{id:guid}", async (Guid Id, ISender sender) =>
        {
            try
            {
                return Results.Ok(await sender.Send(new GetProductByIdQuery(new ProductId(Id))));
            }
            catch (ProductNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }

        });

        app.MapPost("products", async (CreateProductRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateProductCommand>();

            await sender.Send(command);

            return Results.Ok();
        });


        app.MapDelete("products/{id:guid}", async (Guid Id, ISender sender) =>
        {
            try
            {
                await sender.Send(new DeleteProductCommand(new ProductId(Id)));

                return Results.NoContent();
            }
            catch (ProductNotFoundException e)
            {
                return Results.NotFound(e.Message);
            }

        });

        app.MapPut("products/{id:guid}", async (Guid id, [FromBody] UpdateProductRequest request, ISender sender) =>
        {
            var command = new UpdateProductCommand(
                new ProductId(id),
                request.Name,
                request.Sku,
                request.Currency,
                request.Amount);
            try
            {
                await sender.Send(command);

                return Results.NoContent();
            }
            catch (ProductNotFoundException e)
            {

                return Results.NotFound(e.Message);
            }
        });



    }
}
