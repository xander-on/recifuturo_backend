


public static class GetAllRecyclersEndpoint
{
    
    public static void MapGetAllRecyclers( this IEndpointRouteBuilder app )
    {
        app.MapGet(
            "/api/recyclers", 
            async( GetAllRecyclersHandler handler ) => 
                await handler.HandleAsync()
        )
        .WithTags("Recyclers");
    }
}