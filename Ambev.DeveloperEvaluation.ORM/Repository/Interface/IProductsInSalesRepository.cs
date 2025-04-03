using Ambev.DeveloperEvaluation.Domain.Model;

namespace Ambev.DeveloperEvaluation.ORM.Repository.Interface;

public interface IProductsInSalesRepository
{
    #region methods

    Task<ProductsInSalesEntity> CreateAsync(ProductsInSalesEntity product, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(Guid cartId, Guid productId, CancellationToken cancellationToken = default);
    Task<ProductsInSalesEntity?> GetByIdAsync(Guid saleId, Guid productId, CancellationToken cancellationToken = default);
    Task<IEnumerable<ProductsInSalesEntity>> GetAllAsync(CancellationToken cancellationToken = default);

    #endregion
}
