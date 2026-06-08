




public static class RecyclerModule
{
    public static IServiceCollection AddRecyclers(this IServiceCollection services)
    {
        services.AddScoped<RecyclerRepository>();
        services.AddScoped<GetAllRecyclersHandler>();
        services.AddScoped<CreateRecyclerHandler>();
        services.AddScoped<UpdateRecyclerHandler>();
        services.AddScoped<DeleteRecyclerHandler>();
        return services;
    }

    public static IEndpointRouteBuilder MapRecyclers(this IEndpointRouteBuilder app)
    {
        app.MapGetAllRecyclers();
        app.MapCreateRecycler();
        app.MapUpdateRecycler();
        app.MapDeleteRecycler();
        return app;
    }
}