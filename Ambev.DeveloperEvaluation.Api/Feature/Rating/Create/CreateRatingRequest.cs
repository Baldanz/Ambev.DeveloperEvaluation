namespace Ambev.DeveloperEvaluation.Api.Feature.Rating.Create;

/// <summary>
/// Represents a request to create a new Rating in the system.
/// </summary>
public class CreateRatingRequest
{
    #region properties

    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty ;
    public string Category { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public required RatingsRating Rate { get; set; }

    #endregion
}

public class RatingsRating
{
    #region properties

    public int Rate { get; set; }
    public int Count { get; set; }

    #endregion
}