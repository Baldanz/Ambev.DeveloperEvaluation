using Ambev.DeveloperEvaluation.Domain.Model;

namespace Ambev.DeveloperEvaluation.ORM.Repository.Interface
{
    public interface IRatingRepository
    {
        #region methods

        Task<RatingEntity> CreateAsync(RatingEntity productRating, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<RatingEntity?> GetRatingAsync(int rate, CancellationToken cancellationToken = default);
        Task<RatingEntity?> GetByIdAsync(Guid? id, Guid? productId, CancellationToken cancellationToken = default);

        #endregion
    }
}
