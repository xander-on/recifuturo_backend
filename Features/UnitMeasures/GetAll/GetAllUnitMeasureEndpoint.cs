namespace VerticalBackend.Features.UnitMeasures.GetAll;

public static class GetAllUnitMeasuresEndpoint
{
    public static void MapGetAllUnitMeasures(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/unit-measures", async (GetAllUnitMeasuresHandler handler) =>
        {
            return await handler.HandleAsync();
        })
        .WithTags("UnitMeasures");
    }
}