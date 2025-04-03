namespace Ambev.DeveloperEvaluation.Api.Feature.Auth.AuthenticateUserFeature;

public sealed class AuthenticateUserResponse
{
    #region properties

    public string Token { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;

    #endregion
}
