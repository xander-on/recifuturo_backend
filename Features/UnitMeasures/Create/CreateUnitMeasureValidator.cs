using Features.UnitMeasures.Create;
using FluentValidation;

public class CreateUnitMeasureValidator : AbstractValidator<CreateUnitMeasureRequest>
{
    public CreateUnitMeasureValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("El nombre no puede estar vacío")
            .MinimumLength(2).WithMessage("Mínimo 2 caracteres")
            .MaximumLength(50).WithMessage("Máximo 50 caracteres");
    }
}