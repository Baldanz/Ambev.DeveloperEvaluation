using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Handle.Auth.AuthenticateUser;

public class AuthenticateUserValidator : AbstractValidator<AuthenticateUserCommand>
{
    #region constructors

    public AuthenticateUserValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(6);
    }

    #endregion
}
