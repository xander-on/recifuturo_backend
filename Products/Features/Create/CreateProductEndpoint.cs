
namespace RecifuturoBackend.Products.Features.Create;

public static class CreateProductEndpoint
{
    public static void MapCreateProduct(this IEndpointRouteBuilder app)
    {
        
        app.MapPost("/api/products", async (CreateProductRequest request, CreateProductHandler handler) =>
        {
            var result = await handler.HandleAsync(request);

            return Results.Created($"/api/products/{result.Id}", new {
                message = "Producto creado exitosamente",
                data = result.Id
            });
        })
        .WithTags("Products")
        .WithName("CreateProduct");
    }
}