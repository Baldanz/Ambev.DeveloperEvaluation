using Ambev.DeveloperEvaluation.Domain.Model;
using Ambev.DeveloperEvaluation.ORM.Repository;
using Ambev.DeveloperEvaluation.ORM.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Sale;

public class ProductsInSalesRepository : IProductsInSalesRepository
{
    #region attributes

    private readonly DefaultContext _context;

    #endregion

    #region constructors

    public ProductsInSalesRepository(DefaultContext context) => _context = context;

    #endregion

    #region methods

    public async Task<ProductsInSalesEntity> CreateAsync(ProductsInSalesEntity sale, CancellationToken cancellationToken)
    {
        await _context.ProductsInSales.AddAsync(sale, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return sale;
    }

    public async Task<bool> DeleteAsync(Guid cartId, Guid productId, CancellationToken cancellationToken)
    {
        var sale = await GetByIdAsync(cartId, productId, cancellationToken);
        if (sale == null)
            return false;

        _context.ProductsInSales.Remove(sale);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<IEnumerable<ProductsInSalesEntity>> GetAllAsync(CancellationToken cancellationToken)
        => await _context.ProductsInSales.ToListAsync(cancellationToken);

    public async Task<ProductsInSalesEntity?> GetByIdAsync(Guid saleId, Guid productId, CancellationToken cancellationToken)
        => await _context.ProductsInSales.FirstOrDefaultAsync(o => o.SaleId == saleId && o.ProductId == productId, cancellationToken);

    #endregion
}
