using Ambev.DeveloperEvaluation.Application.Handle.ProductsInSales.Create;
using System.Text.Json.Serialization;

namespace Ambev.DeveloperEvaluation.Application.Handle.ProductsInSales.Create;

public class CreateProductsInSalesResult
{
    #region properties

    [JsonIgnore]
    public Guid SaleId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalAmmount { get; set; }

    #endregion
}
