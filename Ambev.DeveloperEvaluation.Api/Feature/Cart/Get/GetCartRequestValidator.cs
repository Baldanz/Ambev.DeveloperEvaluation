using FluentValidation;

namespace Ambev.DeveloperEvaluation.Api.Feature.Ratings.Feature.Cart.Get;

/// <summary>
/// Validator for GetCartRequest
/// </summary>
public class GetCartRequestValidator : AbstractValidator<GetCartRequest>
{
    /// <summary>
    /// Initializes validation rules for GetCartRequest
    /// </summary>
    public GetCartRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Cart ID is required");
    }
}
