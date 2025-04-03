using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Interface;

namespace Ambev.DeveloperEvaluation.Domain.Model;

public class SalesEntity : BaseEntity, ISalesEntity
{
    #region properties

    public DateTime SaleDate { get; set; }
    public Guid UserId { get; set; }
    public decimal SaleAmmount { get; set; }
    public string SaleBranch { get; set; } = string.Empty;
    public required UserEntity Users { get; set; }

    #endregion

    #region constructors

    public SalesEntity() => SaleDate = DateTime.UtcNow;

    #endregion

    #region interface implementation

    string ISalesEntity.Id => Id.ToString();

    #endregion
}
