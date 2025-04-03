using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Model;
using Ambev.DeveloperEvaluation.Domain.Interface;

namespace Ambev.DeveloperEvaluation.Domain.Model;

public class CartEntity : BaseEntity, ICartEntity
{
    #region properties

    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; private set; }
    public required UserEntity Users { get; set; }

    #endregion

    #region constructors

    public CartEntity() => CreatedAt = DateTime.UtcNow;

    #endregion

    #region interface implementation

    string ICartEntity.Id => Id.ToString();

    #endregion
}