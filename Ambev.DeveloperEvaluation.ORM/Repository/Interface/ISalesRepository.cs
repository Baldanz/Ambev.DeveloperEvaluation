using Ambev.DeveloperEvaluation.Domain.Model;

namespace Ambev.DeveloperEvaluation.ORM.Repository.Interface;

public interface ISalesRepository
{
    #region methods

    Task<SalesEntity> CreateAsync(SalesEntity sale, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<SalesEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<SalesEntity>> GetAllAsync(CancellationToken cancellationToken = default);

    #endregion
}
