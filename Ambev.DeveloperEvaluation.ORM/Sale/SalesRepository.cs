using Ambev.DeveloperEvaluation.Domain.Model;
using Ambev.DeveloperEvaluation.ORM.Repository;
using Ambev.DeveloperEvaluation.ORM.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Sale;

public class SalesRepository : ISalesRepository
{
    #region attributes

    private readonly DefaultContext _context;

    #endregion

    #region constructors

    public SalesRepository(DefaultContext context) => _context = context;

    #endregion

    #region methods

    public async Task<SalesEntity> CreateAsync(SalesEntity sale, CancellationToken cancellationToken)
    {
        await _context.Sales.AddAsync(sale, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return sale;
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var sale = await GetByIdAsync(id, cancellationToken);
        if (sale == null)
            return false;

        _context.Sales.Remove(sale);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<IEnumerable<SalesEntity>> GetAllAsync(CancellationToken cancellationToken)
        => await _context.Sales.ToListAsync(cancellationToken);

    public async Task<SalesEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        => await _context.Sales.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);

    #endregion
}
