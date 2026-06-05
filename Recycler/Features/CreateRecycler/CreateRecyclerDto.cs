

using FluentValidation;


public record CreateRecyclerRequest(
    string? Ci, 
    string Name,
    Gender Gender
);


public record CreateRecyclerResponse(
    Guid Id, 
    string? Ci, 
    string Name,
    Gender Gender
);



public class CreateRecyclerValidator : AbstractValidator<CreateRecyclerRequest>
{
    public CreateRecyclerValidator()
    {
        RuleFor(x => x.Name)
        .NotEmpty().WithMessage("El nombre es requerido")
        .MaximumLength(150).WithMessage("El nombre debe tener máximo 150 caracteres");
    }
}