using Ambev.DeveloperEvaluation.WebApi.Features.Rating.DeleteRating;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Rating.Delete;

/// <summary>
/// Validator for DeleteRatingRequest
/// </summary>
public class DeleteRatingRequestValidator : AbstractValidator<DeleteRatingRequest>
{
    /// <summary>
    /// Initializes validation rules for DeleteRatingRequest
    /// </summary>
    public DeleteRatingRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Rating ID is required");
    }
}
