namespace Ambev.DeveloperEvaluation.Api.Feature.Ratings.Feature.Cart.Get;

/// <summary>
/// Request model for getting a user by ID
/// </summary>
public class GetCartRequest
{
    /// <summary>
    /// The unique identifier of the user to retrieve
    /// </summary>
    public Guid Id { get; set; }
}
