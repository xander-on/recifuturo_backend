

using FluentValidation;
using RecifuturoBackend.Products.Features.Get;

public class GetProductsValidator : AbstractValidator<GetProductsRequest>
{
    public GetProductsValidator()
    {
        RuleFor(x => x.Page)
            .GreaterThan(0).WithMessage("La página debe ser mayor a 0");

        RuleFor(x => x.PageSize)
            .GreaterThan(0).WithMessage("El tamaño de página debe ser mayor a 0")
            .LessThanOrEqualTo(100).WithMessage("El tamaño de página no puede ser mayor a 100");
    }
}