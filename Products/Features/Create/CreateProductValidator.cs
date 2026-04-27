using FluentValidation;

namespace RecifuturoBackend.Products.Features.Create;


public class CreateProductValidator:AbstractValidator<CreateProductRequest>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Name)
        .NotEmpty().WithMessage("El nombre es requerido")
        .MaximumLength(150).WithMessage("El nombre debe tener máximo 150 caracteres");
        
        RuleFor(x => x.Prices)
        .NotEmpty().WithMessage("Debe tener al menos un precio");

        RuleFor(x => x.Prices)
        .Must(prices => prices.Any(p =>
            p.ValueA.HasValue ||
            p.ValueB.HasValue ||
            p.ValueC.HasValue ||
            p.ValueD.HasValue
        ))
        .WithMessage("Debe enviar al menos un valor");
    }
}