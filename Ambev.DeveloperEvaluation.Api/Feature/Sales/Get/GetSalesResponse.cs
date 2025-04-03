using Ambev.DeveloperEvaluation.Api.Feature.Ratings.Feature.ProductsInSales.Get;

namespace Ambev.DeveloperEvaluation.Api.Feature.Ratings.Feature.Sales.Get;

/// <summary>
/// API response model for GetSales operation
/// </summary>
public class GetSalesResponse
{
    #region properties

    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime SaleDate { get; private set; }
    public required List<GetProductsInSalesResponse> Products { get; set; } 
        = new List<GetProductsInSalesResponse>();

    #endregion
}
