using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.ProductsInCart.Delete;

/// <summary>
/// Validator for DeleteProductsInCartRequest
/// </summary>
public class DeleteProductsInCartRequestValidator : AbstractValidator<DeleteProductsInCartRequest>
{
    /// <summary>
    /// Initializes validation rules for DeleteProductsInCartRequest
    /// </summary>
    public DeleteProductsInCartRequestValidator()
    {
        RuleFor(x => x.CartId).NotEmpty().WithMessage("Cart is required");
        RuleFor(x => x.ProductId).NotEmpty().WithMessage("Product is required");
    }
}
