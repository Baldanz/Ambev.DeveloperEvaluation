using Ambev.DeveloperEvaluation.Domain.Model;
using Ambev.DeveloperEvaluation.ORM.Repository;
using Ambev.DeveloperEvaluation.ORM.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Cart;

public class CartRepository : ICartRepository
{
    #region attributes

    private readonly DefaultContext _context;

    #endregion

    #region constructors

    public CartRepository(DefaultContext context) => _context = context;

    #endregion

    #region methods
    public async Task<CartEntity> CreateAsync(CartEntity cart, CancellationToken cancellationToken)
    {
        await _context.Carts.AddAsync(cart, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return cart;
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var product = await GetByIdAsync(id, cancellationToken);
        if (product == null)
            return false;

        _context.Carts.Remove(product);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<CartEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => await _context.Carts.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

    public async Task<IEnumerable<CartEntity>> GetAllAsync(CancellationToken cancellationToken)
        => await _context.Carts.ToListAsync(cancellationToken);

    #endregion
}
