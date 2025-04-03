using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Handle.ProductsInCart.Get;

public class GetProductsInCartValidator : AbstractValidator<GetProductsInCartCommand>
{
    /// <summary>
    /// Initializes validation rules for GetProductsInCartCommand
    /// </summary>
    public GetProductsInCartValidator()
    {
        RuleFor(x => x.CartId).NotEmpty().WithMessage("Cart is required");
        RuleFor(x => x.ProductId).NotEmpty().WithMessage("Product is required");
    }
}
