using Ambev.DeveloperEvaluation.Domain.Enum;

namespace Ambev.DeveloperEvaluation.Api.Features.User.Create;

/// <summary>
/// Represents a request to create a new user in the system.
/// </summary>
public class CreateUserRequest
{
    #region properties
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public UserStatus Status { get; set; }
    public UserRole Role { get; set; }
    #endregion
}