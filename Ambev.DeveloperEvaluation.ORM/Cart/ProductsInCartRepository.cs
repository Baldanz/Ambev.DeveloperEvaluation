using Ambev.DeveloperEvaluation.Domain.Model;
using Ambev.DeveloperEvaluation.ORM.Repository;
using Ambev.DeveloperEvaluation.ORM.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Cart
{
    public class ProductsInCartRepository : IProductsInCartRepository
    {
        #region attributes

        private readonly DefaultContext _context;

        #endregion

        #region constructors

        public ProductsInCartRepository(DefaultContext context) => _context = context;

        #endregion

        #region methods

        public async Task<ProductsInCartEntity> CreateAsync(ProductsInCartEntity product, CancellationToken cancellationToken)
        {
            await _context.ProductsInCart.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return product;
        }

        public async Task<bool> DeleteAsync(Guid cartId, Guid productId, CancellationToken cancellationToken = default)
        {
            var product = await GetByIdAsync(cartId, productId, cancellationToken);
            if (product == null)
                return false;

            _context.ProductsInCart.Remove(product);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<ProductsInCartEntity?> GetByIdAsync(Guid cartId, Guid productId, CancellationToken cancellationToken = default)
            => await _context.ProductsInCart.FirstOrDefaultAsync(o => o.CartId == cartId && o.ProductId == productId, cancellationToken);

        public async Task<IEnumerable<ProductsInCartEntity>> GetAllAsync(CancellationToken cancellationToken = default)
            => await _context.ProductsInCart.ToListAsync(cancellationToken);

        #endregion
    }
}
