
namespace RecifuturoBackend.Products.Features.Create;

public static class CreateProductEndpoint
{
    public static void MapCreateProduct(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/products", async (CreateProductRequest request, CreateProductHandler handler) =>
        {
            return await handler.HandleAsync(request);
        })
        .WithTags("Products")
        .WithName("CreateProduct");
    }
}