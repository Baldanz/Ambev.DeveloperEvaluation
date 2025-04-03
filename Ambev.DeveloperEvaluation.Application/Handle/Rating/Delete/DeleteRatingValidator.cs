using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Handle.Rating.Delete;

/// <summary>
/// Validator for DeleteRatingCommand
/// </summary>
public class DeleteRatingValidator : AbstractValidator<DeleteRatingCommand>
{
    /// <summary>
    /// Initializes validation rules for DeleteRatingCommand
    /// </summary>
    public DeleteRatingValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("User ID is required");
    }
}
