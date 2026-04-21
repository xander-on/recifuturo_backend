namespace RecifuturoBackend.Features.UnitMeasures.Create;

public record CreateUnitMeasureRequest(string Name);

public record CreateUnitMeasureResponse(Guid Id, string Name);