namespace RecifuturoBackend.UnitMeasures.Features.Create;

public record CreateUnitMeasureRequest(string Name, string? Abbreviation);

public record CreateUnitMeasureResponse(Guid Id, string Name, string? Abbreviation);