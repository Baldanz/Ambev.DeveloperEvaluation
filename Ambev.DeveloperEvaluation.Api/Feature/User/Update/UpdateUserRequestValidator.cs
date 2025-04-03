using Ambev.DeveloperEvaluation.Domain.Enum;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Api.Features.User.Update;

/// <summary>
/// Validator for UpdateUserRequest that defines validation rules for user creation.
/// </summary>
public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
{
    #region constructors

    /// <summary>
    /// UpdateUserRequestValidator constructor
    /// </summary>
    public UpdateUserRequestValidator()
    {
        RuleFor(user => user.Id).NotEmpty().WithMessage("User ID is required");
        RuleFor(user => user.Email).SetValidator(new EmailValidator());
        RuleFor(user => user.UserName).NotEmpty().Length(3, 50);
        RuleFor(user => user.Password).SetValidator(new PasswordValidator());
        RuleFor(user => user.Phone).Matches(@"^\+?[1-9]\d{1,14}$");
        RuleFor(user => user.Status).NotEqual(UserStatus.Unknown);
        RuleFor(user => user.Role).NotEqual(UserRole.None);
    }
    #endregion
}