using System.Text.Json.Serialization;

namespace Ambev.DeveloperEvaluation.Api.Feature.Ratings.Feature.Ratings.Get;

/// <summary>
/// API response model for GetRating operation
/// </summary>
public class GetRatingResponse
{
    #region proporties

    [JsonIgnore]
    public Guid Id { get; set; }
    [JsonIgnore]
    public Guid CartId { get; set; }
    public int Rate { get; set; }
    public int Count { get; set; }

    #endregion
}
