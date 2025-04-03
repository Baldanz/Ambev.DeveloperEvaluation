using Ambev.DeveloperEvaluation.Domain.Enum;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Handle.User.Update;

public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
{
    #region constructors

    public UpdateUserValidator()
    {
        RuleFor(p => p.Id).NotEmpty().WithMessage("User ID is required");
        RuleFor(p => p.Email).SetValidator(new EmailValidator());
        RuleFor(p => p.UserName).NotEmpty().Length(3, 50);
        RuleFor(p => p.Password).SetValidator(new PasswordValidator());
        RuleFor(p => p.Phone).Matches(@"^\+?[1-9]\d{1,14}$");
        RuleFor(p => p.Status).NotEqual(UserStatus.Unknown);
        RuleFor(p => p.Role).NotEqual(UserRole.None);
    }
    #endregion
}