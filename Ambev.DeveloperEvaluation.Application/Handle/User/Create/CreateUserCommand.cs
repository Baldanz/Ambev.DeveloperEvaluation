using Ambev.DeveloperEvaluation.Domain.Enum;
using Ambev.DeveloperEvaluation.Entity.Validation;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handle.User.Create;

/// <summary>
/// Command for creating a new User.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for creating a User, 
/// including Username, password, phone number, email, status, and role. 
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
/// that returns a <see cref="CreateUserResult"/>.
/// 
/// The data provided in this command is validated using the 
/// <see cref="CreateUserCommandValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class CreateUserCommand : IRequest<CreateUserResult>
{
    #region properties

    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public UserStatus Status { get; set; }
    public UserRole Role { get; set; }

    #endregion

    #region methods

    public ValidationResult Validate()
    {
        var validator = new CreateUserValidator();
        var result = validator.Validate(this);
        return new ValidationResult
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationError)o)
        };
    }

    #endregion
}