using FluentValidation;

namespace Ambev.DeveloperEvaluation.Api.Feature.Ratings.Feature.Ratings.Get;

/// <summary>
/// Validator for GetRatingRequest
/// </summary>
public class GetRatingRequestValidator : AbstractValidator<GetRatingRequest>
{
    /// <summary>
    /// Initializes validation rules for GetRatingRequest
    /// </summary>
    public GetRatingRequestValidator()
    {
        RuleFor(x => x.ProductId)
            .NotEmpty()
            .WithMessage("Product ID is required");
    }
}
