
namespace RecifuturoBackend.Domain.Entities;

public class ProductPrice:Base
{
    public Guid ProductId { get; private set; }
    public Product Product { get; private set; } = null!;

    public Guid UnitMeasureId { get; private set; }
    public UnitMeasure UnitMeasure { get; private set; } = null!;

    public decimal ValueA { get; private set; }
    public decimal ValueB { get; private set; }
    public decimal ValueC { get; private set; }
    public decimal ValueD { get; private set; }

    private ProductPrice() { }

    private ProductPrice(Guid productId, Guid unitMeasureId, decimal a, decimal b, decimal c, decimal d)
    {
        Id = Guid.NewGuid();
        ProductId = productId;
        UnitMeasureId = unitMeasureId;
        ValueA = a;
        ValueB = b;
        ValueC = c;
        ValueD = d;
    }

    public static ProductPrice Create(Guid productId, Guid unitMeasureId, decimal a, decimal b, decimal c, decimal d)
    {
        // Aquí podrías validar que los precios no sean negativos
        if (a < 0 || b < 0 || c < 0 || d < 0)
            throw new ArgumentException("Los precios no pueden ser negativos");

        return new ProductPrice(productId, unitMeasureId, a, b, c, d);
    }

    public void UpdatePrices(decimal a, decimal b, decimal c, decimal d)
    {
        ValueA = a;
        ValueB = b;
        ValueC = c;
        ValueD = d;
    }
}