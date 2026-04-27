
namespace RecifuturoBackend.Products.Features.Create;


public record CreateProductRequest(
    string Name, 
    List<CreateProductPriceRequest> Prices
);


public record CreateProductResponse(Guid Id);



public record CreateProductPriceRequest(
    decimal Amount,
    Guid UnitMeasureId
);
