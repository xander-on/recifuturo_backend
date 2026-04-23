
using RecifuturoBackend.Features.UnitMeasures.GetAll;
using RecifuturoBackend.UnitMeasures.Features.Create;
// using Microsoft.Extensions.DependencyInjection;

namespace RecifuturoBackend.UnitMeasures;

public static class UnitMeasuresModule
{
    public static IServiceCollection AddUnitMeasures(this IServiceCollection services)
    {
        services.AddScoped<CreateUnitMeasureHandler>();
        services.AddScoped<GetAllUnitMeasuresHandler>();
        // services.AddValidatorsFromAssemblyContaining<CreateUnitMeasureValidator>();
        return services;
    }


    public static IEndpointRouteBuilder MapUnitMeasures(this IEndpointRouteBuilder app)
    {
        app.MapCreateUnitMeasure();
        app.MapGetAllUnitMeasures();
        return app;
    }
}