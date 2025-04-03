namespace Ambev.DeveloperEvaluation.WebApi.Features.Rating.DeleteRating;

/// <summary>
/// Request model for deleting a Rating
/// </summary>
public class DeleteRatingRequest
{
    #region properties

    public Guid? Id { get; set; }
    public Guid? CartId { get; set; }

    #endregion
}
