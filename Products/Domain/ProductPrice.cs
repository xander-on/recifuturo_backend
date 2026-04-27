namespace RecifuturoBackend.Products.Domain;

public class ProductPrice : Base
{
    public Guid ProductId { get; private set; }
    public Guid UnitMeasureId { get; private set; }

    public decimal? ValueA { get; private set; }
    public decimal? ValueB { get; private set; }
    public decimal? ValueC { get; private set; }
    public decimal? ValueD { get; private set; }

    private ProductPrice() { }

    private ProductPrice(
        Guid productId, 
        Guid unitMeasureId, 
        decimal? a, 
        decimal? b, 
        decimal? c, 
        decimal? d)
    {
        Id = Guid.NewGuid();
        ProductId = productId;
        UnitMeasureId = unitMeasureId;
        ValueA = a;
        ValueB = b;
        ValueC = c;
        ValueD = d;
    }

    public static ProductPrice Create(
        Guid productId, 
        Guid unitMeasureId, 
        decimal? a, 
        decimal? b, 
        decimal? c, 
        decimal? d
    )
    {
        Validate(a, "ValueA");
        Validate(b, "ValueB");
        Validate(c, "ValueC");
        Validate(d, "ValueD");
        return new ProductPrice(productId, unitMeasureId, a, b, c, d);
    }

    

    private static void Validate(decimal? value, string name)
    {
        if (value.HasValue && value < 0)
            throw new ArgumentException($"{name} no puede ser negativo");
    }
    
}