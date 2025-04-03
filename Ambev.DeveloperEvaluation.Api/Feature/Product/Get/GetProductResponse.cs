using Ambev.DeveloperEvaluation.Api.Feature.Ratings.Feature.Ratings.Get;

namespace Ambev.DeveloperEvaluation.Api.Feature.Ratings.Feature.Product.Get;

/// <summary>
/// API response model for GetProduct operation
/// </summary>
public class GetProductResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public required GetRatingResponse Rating {  get; set; }
}
