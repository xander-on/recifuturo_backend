

using RecifuturoBackend.Products.Features.Create;

namespace RecifuturoBackend.Products;

public static class ProductModule
{
    public static IServiceCollection AddProducts(this IServiceCollection services)
    {
        services.AddScoped<CreateProductHandler>();
        // services.AddScoped<GetAllProductsHandler>();
        return services;
    }


    public static IEndpointRouteBuilder MapProducts(this IEndpointRouteBuilder app)
    {
        app.MapCreateProduct();
        // app.MapGetAllProducts();
        return app;
    }
}