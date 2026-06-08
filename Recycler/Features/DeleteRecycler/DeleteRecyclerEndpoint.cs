


public static class DeleteRecyclerEndpoint
{
    
    public static void MapDeleteRecycler( this IEndpointRouteBuilder app )
    {
        app.MapDelete(
            "/api/recyclers/{id}", 
            async( Guid id, DeleteRecyclerHandler handler ) => 
                await handler.HandleAsync( id )
        )
        .WithTags("Recyclers");
    }
}