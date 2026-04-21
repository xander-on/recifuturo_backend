

namespace RecifuturoBackend.Features.UnitMeasures.Create;

public static class CreateUnitMeasureEndpoint
{
    public static void MapCreateUnitMeasure(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/unit-measures", async (CreateUnitMeasureRequest request, CreateUnitMeasureHandler handler) =>
        {
            return await handler.HandleAsync(request);
        })
        .WithTags("UnitMeasures")
        .WithName("CreateUnitMeasure");
    }
}


