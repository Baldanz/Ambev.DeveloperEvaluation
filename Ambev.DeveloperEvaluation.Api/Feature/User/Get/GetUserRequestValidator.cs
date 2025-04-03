using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.User.GetUser;

/// <summary>
/// Validator for GetUserRequest
/// </summary>
public class GetUserRequestValidator : AbstractValidator<GetUserRequest>
{
    /// <summary>
    /// Initializes validation rules for GetUserRequest
    /// </summary>
    public GetUserRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("User ID is required");
    }
}
