using FluentValidation;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using RecifuturoBackend.Products.Domain;

namespace RecifuturoBackend.Products.Features.Create;

public class CreateProductHandler
{
    private readonly AppDbContext _db;
    private readonly IValidator<CreateProductRequest> _validator;


    public CreateProductHandler(AppDbContext db, IValidator<CreateProductRequest> validator)
    {
        _db = db;
        _validator = validator;
    }  

    public async Task<CreateProductResponse> HandleAsync(CreateProductRequest request)
    {
        var validationResult = await _validator.ValidateAsync(request);
        
        if (!validationResult.IsValid)
             throw new ValidationException(validationResult.Errors);
        
        //aqui validar si el nombre es repetido
        var cleanName = request.Name.Trim().ToUpper();
        var exists = await _db.Products.AnyAsync(x => x.Name.ToUpper() == cleanName);
        
        if (exists)
            throw new ConflictException($"El producto '{cleanName}' ya existe.");

        var product = Product.Create(request.Name);

        foreach (var price in request.Prices)
        {
            var productPrice = ProductPrice.Create(
                product.Id,
                price.UnitMeasureId,
                price.ValueA,
                price.ValueB,
                price.ValueC,
                price.ValueD
            );

            product.AddPrice(productPrice);
        }

        await _db.Products.AddAsync(product);
        await _db.SaveChangesAsync();

        return new CreateProductResponse(product.Id);
    } 
}