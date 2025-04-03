using Ambev.DeveloperEvaluation.Domain.Enum;

namespace Ambev.DeveloperEvaluation.Application.Handle.User.Create;

public class CreateUserResult
{
    #region properties
    public Guid Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public UserStatus Status { get; set; }
    public UserRole Role { get; set; }

    #endregion
}
