using Ambev.DeveloperEvaluation.Domain.Enum;
using Ambev.DeveloperEvaluation.Domain.Model;

namespace Ambev.DeveloperEvaluation.Domain.Specifications;

public class ActiveUserSpecification : ISpecification<UserEntity>
{
    public bool IsSatisfiedBy(UserEntity user)
    {
        return user.Status == UserStatus.Active;
    }
}
