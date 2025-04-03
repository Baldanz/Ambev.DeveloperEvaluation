

namespace Ambev.DeveloperEvaluation.Common.Security.Interface;

public interface IJwtTokenGenerator
{
    #region methods

    string GenerateToken(Ambev.DeveloperEvaluation.Domain.Interface.IUserEntity user);

    #endregion
}