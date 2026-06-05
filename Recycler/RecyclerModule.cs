




public static class RecyclerModule
{
    public static IServiceCollection AddRecyclers(this IServiceCollection services)
    {
        services.AddScoped<GetAllRecyclersHandler>();
        services.AddScoped<CreateRecyclerHandler>();
        return services;
    }

    public static IEndpointRouteBuilder MapRecyclers(this IEndpointRouteBuilder app)
    {
        app.MapGetAllRecyclers();
        app.MapCreateRecycler();
        return app;
    }
}