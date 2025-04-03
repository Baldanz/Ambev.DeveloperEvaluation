namespace Ambev.DeveloperEvaluation.Common.Security.Interface
{
    public interface IPasswordEncryption
    {
        #region methods

        string HashPassword(string password);

        bool VerifyPassword(string password, string hash);

        #endregion
    }
}
