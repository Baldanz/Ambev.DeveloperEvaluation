using Ambev.DeveloperEvaluation.Api.Feature.Ratings.Feature.Ratings.Get;
using System.Text.Json.Serialization;

namespace Ambev.DeveloperEvaluation.Api.Feature.Ratings.Feature.ProductsInCart.Get;

/// <summary>
/// API response model for GetProductsInCart operation
/// </summary>
public class GetProductsInCartResponse
{
    #region properties

    [JsonIgnore]
    public Guid CartId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }

    #endregion
}
