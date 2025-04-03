using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Interface;

namespace Ambev.DeveloperEvaluation.Domain.Model;

public class RatingEntity : BaseEntity, IRatingEntity
{
    #region properties

    public Guid ProductId { get; set; }
    public int Rate { get; set; }
    public int Count { get; set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public required ProductEntity Products { get; set; }

    #endregion

    #region constructors

    public RatingEntity()
    {
        CreatedAt = DateTime.UtcNow;
    }

    #endregion

    #region interface implementation

    string IRatingEntity.Id => Id.ToString();

    #endregion
}
