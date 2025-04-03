using Ambev.DeveloperEvaluation.Domain.Model;

namespace Ambev.DeveloperEvaluation.ORM.Repository.Interface
{
    public interface IProductRepository
    {
        #region methods

        Task<ProductEntity> CreateAsync(ProductEntity product, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<ProductEntity?> GetByProductAsync(string title, string description, string category, CancellationToken cancellationToken = default);
        Task<ProductEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<ProductEntity>> GetAllAsync(CancellationToken cancellationToken = default);

        #endregion
    }
}
