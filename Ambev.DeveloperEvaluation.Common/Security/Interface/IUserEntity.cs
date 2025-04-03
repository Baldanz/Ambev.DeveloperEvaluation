namespace Ambev.DeveloperEvaluation.Common.Security.Interface;

public interface IUserEntity
{
    #region properties

    public string Id { get; }
    public string UserName { get; }
    public string Role { get; }

    #endregion
}
