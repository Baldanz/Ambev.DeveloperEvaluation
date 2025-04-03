using FluentValidation;

namespace Ambev.DeveloperEvaluation.Api.Feature.Cart.Create;

public class CreateCartRequestValidator : AbstractValidator<CreateCartRequest>
{
    public CreateCartRequestValidator()
    {
        RuleFor(p => p.UserId).NotEmpty().WithMessage("User is mandatory");
        RuleFor(p => p.Products).NotEmpty().WithMessage("Product is mandatory");
    }
}