
using RecifuturoBackend.Products.Domain;

namespace RecifuturoBackend.Products.Features.Get;

public record GetProductsRequest(int Page = 1, int PageSize = 10);



// RESPONSE
public record GetProductsResponse(
    List<ProductDto> Data,
    int Page,
    int PageSize,
    int Total
);


public record ProductDto(
    Guid Id,
    string Name,
    List<ProductPriceDto> Prices,
    string Status,
    bool IsActive
);

public record ProductPriceDto(
    decimal? ValueA,
    decimal? ValueB,
    decimal? ValueC,
    decimal? ValueD,
    Guid UnitMeasureId
);