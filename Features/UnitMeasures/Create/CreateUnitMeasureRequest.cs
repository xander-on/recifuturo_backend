namespace RecifuturoBackend.Features.UnitMeasures.Create;

public record CreateUnitMeasureRequest(string Name);

// Si quisieras devolver un objeto específico en lugar de la entidad completa:
public record CreateUnitMeasureResponse(Guid Id, string Name);