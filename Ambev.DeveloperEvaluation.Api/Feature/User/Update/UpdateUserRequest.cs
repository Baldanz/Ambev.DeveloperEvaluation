using Ambev.DeveloperEvaluation.Domain.Enum;
using System.Text.Json.Serialization;

namespace Ambev.DeveloperEvaluation.Api.Features.User.Update;

/// <summary>
/// Represents a request to create a new user in the system.
/// </summary>
public class UpdateUserRequest
{
    #region properties

    public Guid Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    [JsonIgnore]
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public UserStatus Status { get; set; }
    public UserRole Role { get; set; }
    #endregion
}