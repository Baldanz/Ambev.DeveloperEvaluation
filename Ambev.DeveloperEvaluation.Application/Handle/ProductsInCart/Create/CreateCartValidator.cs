using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Handle.ProductsInCart.Create;

public class CreateProductsInCartValidator : AbstractValidator<CreateProductsInCartCommand>
{
    #region constructors

    public CreateProductsInCartValidator() 
    {
        RuleFor(p => p.CartId).NotEmpty().WithMessage("Cart is mandatory");
        RuleFor(p => p.ProductId).NotEmpty().WithMessage("Product is mandatory");
        RuleFor(p => p.Quantity).NotEmpty().WithMessage("Quantity is mandatory");
    }

    #endregion
}
