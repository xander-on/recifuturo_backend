using FluentValidation;


namespace RecifuturoBackend.UnitMeasures.Features.Create;

public class CreateUnitMeasureValidator : AbstractValidator<CreateUnitMeasureRequest>
{
    public CreateUnitMeasureValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("El nombre no puede estar vacío")
            .MinimumLength(2).WithMessage("Mínimo 2 caracteres")
            .MaximumLength(50).WithMessage("Máximo 50 caracteres");


        RuleFor(x => x.Abbreviation)
            .MaximumLength(10)
            .When(x => x.Abbreviation != null);
    }
}