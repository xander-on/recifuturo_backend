


using Microsoft.AspNetCore.Mvc;

namespace RecifuturoBackend.Products.Features.Get;

public static class GetProductsEndpoint
{
    public static void MapGetProducts(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/products", async (
            [AsParameters] GetProductsRequest request, 
            [FromServices] GetProductsHandler handler
        ) =>
        {
            var result = await handler.HandleAsync(request);
            return Results.Ok(result);
        })
        .WithTags("Products");
    }
}