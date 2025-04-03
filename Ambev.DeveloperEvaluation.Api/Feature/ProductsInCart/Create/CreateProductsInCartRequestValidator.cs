using FluentValidation;

namespace Ambev.DeveloperEvaluation.Api.Feature.ProductsInCart.Create;

public class CreateProductsInCartRequestValidator : AbstractValidator<CreateProductsInCartRequest>
{
    public CreateProductsInCartRequestValidator()
    {
        RuleFor(p => p.CartId).NotEmpty().WithMessage("Cart is mandatory");
        RuleFor(p => p.ProductId).NotEmpty().WithMessage("Product is mandatory");
        RuleFor(p => p.Quantity).NotEmpty().WithMessage("Quantity is mandatory");
    }
}