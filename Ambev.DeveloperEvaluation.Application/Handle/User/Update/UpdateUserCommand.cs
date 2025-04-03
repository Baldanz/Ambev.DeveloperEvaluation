using Ambev.DeveloperEvaluation.Domain.Enum;
using Ambev.DeveloperEvaluation.Entity.Validation;
using FluentValidation;
using MediatR;
using System.Text.Json.Serialization;

namespace Ambev.DeveloperEvaluation.Application.Handle.User.Update;

/// <summary>
/// Command for creating a new User.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for creating a User, 
/// including Username, password, phone number, email, status, and role. 
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
/// that returns a <see cref="UpdateUserResult"/>.
/// 
/// The data provided in this command is validated using the 
/// <see cref="UpdateUserCommandValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class UpdateUserCommand : IRequest<UpdateUserResult>
{
    #region properties

    public Guid Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime UpdatedAt { get; set; }
    public UserStatus Status { get; set; }
    public UserRole Role { get; set; }

    #endregion

    #region methods

    public ValidationResult Validate()
    {
        var validator = new UpdateUserValidator();
        var result = validator.Validate(this);
        return new ValidationResult
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationError)o)
        };
    }

    #endregion
}