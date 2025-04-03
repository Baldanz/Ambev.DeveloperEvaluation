using Ambev.DeveloperEvaluation.Application.Handle.Rating.Get;

namespace Ambev.DeveloperEvaluation.Application.Handle.Product.Get;

public class GetProductResult
{
    #region properties

    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public required GetRatingResult Rating { get; set; }
    #endregion
}