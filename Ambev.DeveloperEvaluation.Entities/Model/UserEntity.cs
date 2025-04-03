using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enum;
using Ambev.DeveloperEvaluation.Domain.Interface;
using Ambev.DeveloperEvaluation.Entity.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Model;

public class UserEntity : BaseEntity, IUserEntity
{
	#region properties
	public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public UserRole Role { get; set; }
    public UserStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; } = null;
    #endregion

    #region interface implementation
    string IUserEntity.Id => Id.ToString();
    string IUserEntity.UserName => UserName;
    string IUserEntity.UserRole => Role.ToString();
    #endregion

    #region constructors
    /// <summary>
    /// UserEntity constructor
    /// </summary>
    public UserEntity()
    {
        CreatedAt = DateTime.UtcNow;
    }
    #endregion

    #region methods for testing

    public ValidationResult Validate()
    {
        var validator = new UserValidator();
        var result = validator.Validate(this);
        return new ValidationResult
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationError)o)
        };
    }

    public void Activate()
    {
        Status = UserStatus.Active;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Deactivate()
    {
        Status = UserStatus.Inactive;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Suspend()
    {
        Status = UserStatus.Suspended;
        UpdatedAt = DateTime.UtcNow;
    }

    #endregion
}
