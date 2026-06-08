




public static class RecyclerModule
{
    public static IServiceCollection AddRecyclers(this IServiceCollection services)
    {
        services.AddScoped<RecyclerRepository>();
        services.AddScoped<GetAllRecyclersHandler>();
        services.AddScoped<CreateRecyclerHandler>();
        services.AddScoped<UpdateRecyclerHandler>();
        return services;
    }

    public static IEndpointRouteBuilder MapRecyclers(this IEndpointRouteBuilder app)
    {
        app.MapGetAllRecyclers();
        app.MapCreateRecycler();
        app.MapUpdateRecycler();
        return app;
    }
}