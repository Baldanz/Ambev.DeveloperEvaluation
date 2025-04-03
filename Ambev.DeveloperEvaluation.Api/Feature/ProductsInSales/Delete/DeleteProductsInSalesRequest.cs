namespace Ambev.DeveloperEvaluation.WebApi.Features.ProductsInSales.Delete;

/// <summary>
/// Request model for deleting a ProductsInSales
/// </summary>
public class DeleteProductsInSalesRequest
{
    /// <summary>
    /// The unique identifier of the ProductsInSales to delete
    /// </summary>
    public Guid SaleId { get; set; }
    public Guid ProductId { get; set; }
}
