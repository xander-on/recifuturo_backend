
namespace VerticalBackend.Domain.Entities;


public class UnitMeasure : Base
{
    public string Name { get; set; } = string.Empty;

    public ICollection<ProductPrice> Prices { get; set; } = [];

    public UnitMeasure() { }

    public UnitMeasure(string name)
    {
        Name = name.Trim().ToUpper();
    }
}