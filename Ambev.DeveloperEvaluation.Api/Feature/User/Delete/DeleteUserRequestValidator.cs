using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.User.Delete;

/// <summary>
/// Validator for DeleteUserRequest
/// </summary>
public class DeleteUserRequestValidator : AbstractValidator<DeleteUserRequest>
{
    /// <summary>
    /// Initializes validation rules for DeleteUserRequest
    /// </summary>
    public DeleteUserRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("User ID is required");
    }
}
