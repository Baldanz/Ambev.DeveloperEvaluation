using Ambev.DeveloperEvaluation.Api.Feature.Rating.Create;

namespace Ambev.DeveloperEvaluation.Api.Feature.Product.Create;

public class CreateProductResponse
{
    #region properties
    
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public decimal Price { get; set; } = 0;
    public required CreateRatingResponse Rating { get; set; }

    #endregion
}
