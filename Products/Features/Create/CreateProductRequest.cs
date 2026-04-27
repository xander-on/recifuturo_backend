
namespace RecifuturoBackend.Products.Features.Create;


public record CreateProductRequest(
    string Name, 
    List<CreateProductPriceRequest> Prices
);

public record CreateProductPriceRequest(
    decimal? ValueA,
    decimal? ValueB,
    decimal? ValueC,
    decimal? ValueD,
    Guid UnitMeasureId
);



// RESPONSE
public record CreateProductResponse(Guid Id);



