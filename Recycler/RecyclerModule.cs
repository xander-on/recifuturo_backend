




public static class RecyclerModule
{
    public static IServiceCollection AddRecyclers(this IServiceCollection services)
    {
        services.AddScoped<GetAllRecyclersHandler>();
        return services;
    }

    public static IEndpointRouteBuilder MapRecyclers(this IEndpointRouteBuilder app)
    {
        app.MapGetAllRecyclers();
        return app;
    }
}