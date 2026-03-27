using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistence;
using Domain.Entities;
using FluentValidation;

namespace Features.UnitMeasures.Create;

public class CreateUnitMeasureHandler
{
    private readonly AppDbContext _db;
    private readonly IValidator<CreateUnitMeasureRequest> _validator;

    public CreateUnitMeasureHandler(AppDbContext db, IValidator<CreateUnitMeasureRequest> validator)
    {
        _db = db;
        _validator = validator;
    }

    public async Task<IResult> HandleAsync(CreateUnitMeasureRequest request)
    {
        
        var validationResult = await _validator.ValidateAsync(request);
        if (!validationResult.IsValid)
            return Results.ValidationProblem(validationResult.ToDictionary());
            
        // 1. Validaciones de entrada
        if (string.IsNullOrWhiteSpace(request.Name))
            return Results.BadRequest("El nombre no puede estar vacío.");

        // 2. Lógica de negocio (Evitar duplicados)
        var cleanName = request.Name.Trim().ToUpper();
        var exists = await _db.UnitMeasures.AnyAsync(x => x.Name == cleanName);
        
        if (exists)
            return Results.Conflict($"La unidad '{cleanName}' ya existe.");

        // 3. Persistencia
        var unit = new UnitMeasure(request.Name);
        _db.UnitMeasures.Add(unit);
        await _db.SaveChangesAsync();

        var response = new CreateUnitMeasureResponse(unit.Id, unit.Name);
        return Results.Created($"/api/unit-measures/{unit.Id}", response);
    }
}