using Ambev.DeveloperEvaluation.Application.Handle.ProductsInSales.Get;

namespace Ambev.DeveloperEvaluation.Application.Handle.Sales.Get;

public class GetSalesResult
{
    #region properties

    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime SaleDate { get; private set; }
    public required List<GetProductsInSalesResult> Products { get; set; } 
        = new List<GetProductsInSalesResult>();

    #endregion
}