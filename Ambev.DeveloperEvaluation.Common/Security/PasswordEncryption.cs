using Ambev.DeveloperEvaluation.Common.Security.Interface;

namespace Ambev.DeveloperEvaluation.Common.Security;

public class PasswordEncryption : IPasswordEncryption
{
    #region methods

    /// <summary>
    /// password encryption with hash algorithm
    /// </summary>
    /// <param name="password">password having no encryption</param>
    /// <returns>encrypted password</returns>
    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    /// <summary>
    /// password hash verification
    /// </summary>
    /// <param name="password">password having no encryption</param>
    /// <param name="hash">enncrypted password</param>
    /// <returns>passoword verification</returns>
    public bool VerifyPassword(string password, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(password, hash);
    }

    #endregion
}
