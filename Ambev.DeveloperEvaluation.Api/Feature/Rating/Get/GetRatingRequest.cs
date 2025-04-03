namespace Ambev.DeveloperEvaluation.Api.Feature.Ratings.Feature.Ratings.Get;

/// <summary>
/// Request model for getting a user by ID
/// </summary>
public class GetRatingRequest
{
    #region properties

    public Guid? Id { get; set; }

    public Guid? ProductId { get; set; }

    #endregion
}
