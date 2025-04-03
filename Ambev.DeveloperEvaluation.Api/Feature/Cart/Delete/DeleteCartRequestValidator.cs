using Ambev.DeveloperEvaluation.WebApi.Features.Cart.DeleteCart;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Cart.Delete;

/// <summary>
/// Validator for DeleteCartRequest
/// </summary>
public class DeleteCartRequestValidator : AbstractValidator<DeleteCartRequest>
{
    /// <summary>
    /// Initializes validation rules for DeleteCartRequest
    /// </summary>
    public DeleteCartRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Cart ID is required");
    }
}
