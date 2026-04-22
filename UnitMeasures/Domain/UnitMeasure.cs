
namespace RecifuturoBackend.UnitMeasures.Domain;

public class UnitMeasure : Base
{
    public string Name { get; set; } = string.Empty;
    public string? Abbreviation { get; set; }

    public UnitMeasure() { }

    public UnitMeasure(string name, string? abbreviation)
    {
        Name = name.Trim().ToUpper();

        Abbreviation = string.IsNullOrWhiteSpace(abbreviation)
        ? null
        : abbreviation.Trim().ToUpper();
    }
}