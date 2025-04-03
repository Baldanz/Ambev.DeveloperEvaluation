using Ambev.DeveloperEvaluation.Domain.Enum;
using System.Text.Json.Serialization;

namespace Ambev.DeveloperEvaluation.Application.Handle.User.Get;

public class GetUserResult
{
    #region properties
    public Guid Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;

    [JsonIgnore]
    public DateTime CreatedAt { get; set; }
    public UserRole Role { get; set; }
    public UserStatus Status { get; set; }
    #endregion
}
