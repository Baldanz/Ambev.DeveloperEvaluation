namespace Ambev.DeveloperEvaluation.Application.Handle.Auth.AuthenticateUser;

public sealed class AuthenticateUserResult
{
    #region properties

    public string Token { get; set; } = string.Empty;
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;

    #endregion
}
