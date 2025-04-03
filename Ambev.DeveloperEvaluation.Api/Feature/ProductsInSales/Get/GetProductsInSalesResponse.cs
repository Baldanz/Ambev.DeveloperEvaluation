using System.Text.Json.Serialization;

namespace Ambev.DeveloperEvaluation.Api.Feature.Ratings.Feature.ProductsInSales.Get;

/// <summary>
/// API response model for GetProductsInSales operation
/// </summary>
public class GetProductsInSalesResponse
{
    #region properties

    [JsonIgnore]
    public Guid CartId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }

    #endregion
}
