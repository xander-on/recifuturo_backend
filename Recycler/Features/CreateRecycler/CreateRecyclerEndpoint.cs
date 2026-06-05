



public static class CreateRecyclerEndpoint
{
    public static void MapCreateRecycler( this IEndpointRouteBuilder app )
    {
        app.MapPost(
            "/api/recyclers", 
            async( CreateRecyclerHandler handler, CreateRecyclerRequest request ) => 
                await handler.HandleAsync( request )
        )
        .WithTags("Recyclers");
    }
}