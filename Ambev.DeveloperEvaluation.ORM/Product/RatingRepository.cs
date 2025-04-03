using Ambev.DeveloperEvaluation.Domain.Model;
using Ambev.DeveloperEvaluation.ORM.Repository;
using Ambev.DeveloperEvaluation.ORM.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.CartRating;

public class RatingRepository : IRatingRepository
{
    #region attributes

    private readonly DefaultContext _context;

    #endregion

    #region constructors

    public RatingRepository(DefaultContext context) => _context = context;

    #endregion

    #region methods
    public async Task<RatingEntity> CreateAsync(RatingEntity rating, CancellationToken cancellationToken)
    {
        await _context.Ratings.AddAsync(rating, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return rating;
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var product = await GetByIdAsync(id, null , cancellationToken);
        if (product == null)
            return false;

        _context.Ratings.Remove(product);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<RatingEntity?> GetRatingAsync(int rate, CancellationToken cancellationToken)
        => await _context.Ratings.FirstOrDefaultAsync(o => o.Rate == rate, cancellationToken);

    public async Task<RatingEntity?> GetByIdAsync(Guid? id, Guid? productId, CancellationToken cancellationToken)
        => await _context.Ratings.FirstOrDefaultAsync(o => o.Id == id || o.ProductId == productId, cancellationToken);

    #endregion
}
