using Ambev.DeveloperEvaluation.Domain.Model;

namespace Ambev.DeveloperEvaluation.ORM.Repository.Interface;

public interface ICartRepository
{
    #region methods
    Task<CartEntity> CreateAsync(CartEntity product, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<CartEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<CartEntity>> GetAllAsync(CancellationToken cancellationToken = default);

    #endregion
}
