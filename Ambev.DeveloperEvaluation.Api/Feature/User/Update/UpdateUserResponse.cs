using Ambev.DeveloperEvaluation.Domain.Enum;

namespace Ambev.DeveloperEvaluation.Api.Features.User.Update;

public class UpdateUserResponse
{
    #region properties
    public Guid Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public UserRole Role { get; set; }
    public UserStatus Status { get; set; }
    #endregion
}
