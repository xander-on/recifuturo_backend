


namespace RecifuturoBackend.Features.UnitMeasures.GetAll;

public record UnitMeasureResponse(
    Guid Id, 
    string Name, 
    bool IsActive, 
    string? Abbreviation = null
);