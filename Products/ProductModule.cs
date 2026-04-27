

using RecifuturoBackend.Products.Features.Create;
using RecifuturoBackend.Products.Features.Get;

namespace RecifuturoBackend.Products;

public static class ProductModule
{
    public static IServiceCollection AddProducts(this IServiceCollection services)
    {
        services.AddScoped<CreateProductHandler>();
        services.AddScoped<GetProductsHandler>();
        return services;
    }


    public static IEndpointRouteBuilder MapProducts(this IEndpointRouteBuilder app)
    {
        app.MapCreateProduct();
        app.MapGetProducts();
        return app;
    }
}