namespace Ambev.DeveloperEvaluation.Domain.Model;

public class ProductsInSalesEntity
{
    #region properties

    public Guid SaleId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalAmmount { get; set; }
    public required SalesEntity Sales { get; set; }
    public required ProductEntity Products { get; set; }

    #endregion
}
