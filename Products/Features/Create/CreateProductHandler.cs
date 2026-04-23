using FluentValidation;
using Infrastructure.Persistence;

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

    public async Task<IResult> HandleAsync(CreateProductRequest request)
    {
        var validationResult = await _validator.ValidateAsync(request);
        
        if (!validationResult.IsValid)
            return Results.ValidationProblem(validationResult.ToDictionary());

        Console.WriteLine($"Nombre: {request.Name}");
        
        foreach (var price in request.Prices)
            Console.WriteLine($"Precio: {price.Amount}, Unidad: {price.UnitMeasureId}");

        return Results.Ok("Producto creado exitosamente");
    } 
}