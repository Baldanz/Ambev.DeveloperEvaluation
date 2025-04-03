using Ambev.DeveloperEvaluation.Domain.Model;

namespace Ambev.DeveloperEvaluation.ORM.Repository.Interface
{
    public interface IProductsInCartRepository
    {
        Task<ProductsInCartEntity> CreateAsync(ProductsInCartEntity product, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(Guid cartId, Guid productId, CancellationToken cancellationToken = default);
        Task<ProductsInCartEntity?> GetByIdAsync(Guid cartId, Guid productId, CancellationToken cancellationToken = default);
        Task<IEnumerable<ProductsInCartEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
