namespace Ambev.DeveloperEvaluation.Application.Handle.ProductsInSales.Get;

public class GetProductsInSalesResult
{
    #region properties

    public Guid SaleId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalAmmount { get; set; }

    #endregion
}