using Ambev.DeveloperEvaluation.Application.Handle.Rating.Create;
using System.Text.Json.Serialization;

namespace Ambev.DeveloperEvaluation.Api.Feature.Product.Create;

/// <summary>
/// Represents a request to create a new Product in the system.
/// </summary>
public class CreateProductRequest
{
    #region properties

    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public decimal Price { get; set; } = 0;
    public required CreateRatingCommand Rate { get; set; }

    #endregion
}