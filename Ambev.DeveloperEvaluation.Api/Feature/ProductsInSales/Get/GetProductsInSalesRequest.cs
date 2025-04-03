namespace Ambev.DeveloperEvaluation.Api.Feature.Feature.ProductsInSales.Get;

/// <summary>
/// Request model for getting a user by ID
/// </summary>
public class GetProductsInSalesRequest
{
    #region properties

    public Guid SaleId { get; set; }
    public Guid ProductId { get; set; }

    #endregion
}
