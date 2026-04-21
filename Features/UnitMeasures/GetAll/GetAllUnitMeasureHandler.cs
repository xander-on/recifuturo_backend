using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence;

namespace RecifuturoBackend.Features.UnitMeasures.GetAll;

public class GetAllUnitMeasuresHandler
{
    private readonly AppDbContext _db;

    public GetAllUnitMeasuresHandler(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IResult> HandleAsync()
    {
        var units = await _db.UnitMeasures
            .AsNoTracking() // Mejora el rendimiento porque es solo lectura
            .Select(u => new UnitMeasureResponse(u.Id, u.Name, u.IsActive))
            .ToListAsync();

        return Results.Ok(units);
    }
}