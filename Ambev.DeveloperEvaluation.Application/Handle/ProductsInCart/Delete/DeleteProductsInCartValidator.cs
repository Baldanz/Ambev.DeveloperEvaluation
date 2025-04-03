using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Handle.ProductsInCart.Delete;

/// <summary>
/// Validator for DeleteProductsInCartCommand
/// </summary>
public class DeleteProductsInCartValidator : AbstractValidator<DeleteProductsInCartCommand>
{
    /// <summary>
    /// Initializes validation rules for DeleteProductsInCartCommand
    /// </summary>
    public DeleteProductsInCartValidator()
    {
        RuleFor(x => x.CartId).NotEmpty().WithMessage("Cart is required");
        RuleFor(x => x.ProductId).NotEmpty().WithMessage("Product is required");
    }
}
