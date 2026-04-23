using FluentValidation;

namespace RecifuturoBackend.Products.Features.Create;


public class CreateProductValidator:AbstractValidator<CreateProductRequest>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Prices)
        .NotEmpty().WithMessage("Debe tener al menos un precio");
    }
}