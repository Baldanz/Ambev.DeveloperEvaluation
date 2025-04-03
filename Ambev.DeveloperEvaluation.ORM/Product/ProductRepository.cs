using Ambev.DeveloperEvaluation.Domain.Model;
using Ambev.DeveloperEvaluation.ORM.Repository;
using Ambev.DeveloperEvaluation.ORM.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Product;

public class ProductRepository : IProductRepository
{
    #region attributes

    private readonly DefaultContext _context;

    #endregion

    #region constructors

    public ProductRepository(DefaultContext context) => _context = context;

    #endregion

    #region methods
    public async Task<ProductEntity> CreateAsync(ProductEntity product, CancellationToken cancellationToken)
    {
        await _context.Products.AddAsync(product, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return product;
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var product = await GetByIdAsync(id, cancellationToken);
        if (product == null)
            return false;

        _context.Products.Remove(product);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<ProductEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Products.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
    }

    public async Task<ProductEntity?> GetByProductAsync(string title, string description, string category, CancellationToken cancellationToken)
    {
        return await _context.Products
            .FirstOrDefaultAsync(u => u.Title == title && u.Description == description && u.Category == category, cancellationToken);
    }

    public async Task<IEnumerable<ProductEntity>> GetAllAsync(CancellationToken cancellationToken)
    => await _context.Products.ToListAsync(cancellationToken);

    #endregion
}
