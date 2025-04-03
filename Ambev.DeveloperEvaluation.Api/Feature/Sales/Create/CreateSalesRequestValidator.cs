using FluentValidation;

namespace Ambev.DeveloperEvaluation.Api.Feature.Sales.Create;

public class CreateSalesRequestValidator : AbstractValidator<CreateSalesRequest>
{
    public CreateSalesRequestValidator()
    {
        RuleFor(p => p.UserId).NotEmpty().WithMessage("User is mandatory");
        RuleFor(p => p.Products).NotEmpty().WithMessage("Product is mandatory");
    }
}