using Ambev.DeveloperEvaluation.Application.Handle.Rating.Create;

namespace Ambev.DeveloperEvaluation.Api.Feature.ProductsInSales.Create;

/// <summary>
/// Represents a request to create a new ProductsInSales in the system.
/// </summary>
public class CreateProductsInSalesRequest
{
    #region properties

    public Guid SaleId {  get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }

    #endregion
}