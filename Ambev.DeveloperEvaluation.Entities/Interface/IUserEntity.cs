namespace Ambev.DeveloperEvaluation.Domain.Interface;

public interface IUserEntity
{
    #region properties
    public string Id { get; }
    public string UserName { get; }
    public string UserRole { get; }
    #endregion
}
