using FluentValidation;

namespace Ambev.DeveloperEvaluation.Api.Feature.Auth.AuthenticateUserFeature;

public class AuthenticateUserRequestValidator : AbstractValidator<AuthenticateUserRequest>
{
    #region constructors

    public AuthenticateUserRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required")
            .EmailAddress()
            .WithMessage("Invalid email format");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required");
    }

    #endregion
}
