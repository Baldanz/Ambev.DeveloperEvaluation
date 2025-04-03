using Ambev.DeveloperEvaluation.Domain.Enum;
using System.Text.Json.Serialization;

namespace Ambev.DeveloperEvaluation.Api.Features.User.Get;

public class GetUserResponse
{
    #region properties
    public Guid Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;

    [JsonIgnore]
    public DateTime CreateAt { get; set; }
    public UserRole Role { get; set; }
    public UserStatus Status { get; set; }
    #endregion
}
