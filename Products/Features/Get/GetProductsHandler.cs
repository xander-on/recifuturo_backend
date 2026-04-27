


using FluentValidation;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using RecifuturoBackend.Products.Domain;

namespace RecifuturoBackend.Products.Features.Get;

public class GetProductsHandler
{
    private readonly AppDbContext _db;
    private readonly IValidator<GetProductsRequest> _validator;

    public GetProductsHandler(AppDbContext db, IValidator<GetProductsRequest> validator)
    {
        _db = db;
        _validator = validator;
    }


    public async Task<GetProductsResponse> HandleAsync(GetProductsRequest request)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var query = _db.Products
            .AsNoTracking() // Mejora el rendimiento no guarda en memoria
            .Include(p => p.Prices)
            .OrderBy(p => p.CreatedAt)
            .AsQueryable();

        var total = await query.CountAsync();

        var products = await query
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(p => new ProductDto(
                p.Id,
                p.Name,
                p.Prices.Select(pp => new ProductPriceDto(
                    pp.ValueA,
                    pp.ValueB,
                    pp.ValueC,
                    pp.ValueD,
                    pp.UnitMeasureId
                )).ToList(),
                p.Status.ToString(),
                p.Status == ProductStatus.Active
            ))
            .ToListAsync();

        return new GetProductsResponse(
            products,
            request.Page,
            request.PageSize,
            total
        );
    }

}