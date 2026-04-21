
using RecifuturoBackend.Domain.Enums;

namespace RecifuturoBackend.Domain.Entities;

public class Product:Base
{
    public string Name { get; private set; } = null!;
    public List<ProductPrice> Prices { get; private set; } = [];
    public ProductStatus Status { get; private set; }

    private Product() { }

    private Product(Guid id, string name, ProductStatus status)
    {
        Id = id;
        Name = name;
        Status = status;
    }

    public static Product Create(string name)
    {
        return new Product(
            Guid.NewGuid(),
            name,
            ProductStatus.Active
        );
    }
}
