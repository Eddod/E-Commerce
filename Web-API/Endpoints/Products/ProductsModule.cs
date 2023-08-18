using Application.Products;
using Carter;
using Mapster;
using MediatR;

namespace Web_API.Endpoints.Products
{
    public class ProductsModule : ICarterModule
    {
        public ProductsModule()
            : base()
        {
            
        }
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/products", async (CreateProductRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateProductCommand>();

                await sender.Send(command);

                return Results.Ok();
            });

        }
    }
}
