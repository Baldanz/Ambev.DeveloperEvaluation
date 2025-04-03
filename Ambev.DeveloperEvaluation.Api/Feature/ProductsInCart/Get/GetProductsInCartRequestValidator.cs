using FluentValidation;

namespace Ambev.DeveloperEvaluation.Api.Feature.Feature.ProductsInCart.Get;
/// <summary>
/// Validator for GetProductsInCartRequest
/// </summary>
public class GetProductsInCartRequestValidator : AbstractValidator<GetProductsInCartRequest>
{
    /// <summary>
    /// Initializes validation rules for GetProductsInCartRequest
    /// </summary>
    public GetProductsInCartRequestValidator()
    {
        RuleFor(x => x.CartId).NotEmpty().WithMessage("Cart is required");
        RuleFor(x => x.ProductId).NotEmpty().WithMessage("Product is required");
    }
}
