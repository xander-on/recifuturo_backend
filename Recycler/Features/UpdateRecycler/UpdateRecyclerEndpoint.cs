


public static class UpdateRecyclerEndpoint
{
    public static void MapUpdateRecycler(this IEndpointRouteBuilder app)
    {
        Console.WriteLine("UpdateRecycler endpoint initialized.");
        app.MapPatch(
            "/api/recyclers/{id}",
            async( UpdateRecyclerHandler handler, UpdateRecyclerRequest request, Guid id ) =>
                await handler.HandleAsync(id, request)
        )
        .WithTags("Recyclers");
    }
}