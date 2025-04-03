using Ambev.DeveloperEvaluation.Application.Handle.ProductsInSales.Create;

namespace Ambev.DeveloperEvaluation.Application.Handle.Sales.Create;

public class CreateSalesResult
{
    #region properties

    public Guid Id { get; set; }
    public DateTime SaleDate { get; set; }
    public Guid UserId { get; set; }
    public decimal SaleAmmount { get; set; }
    public string SaleBranch { get; set; } = string.Empty;
    public required List<CreateProductsInSalesResult> Products { get; set; } = new List<CreateProductsInSalesResult>();

    #endregion
}
