using Ambev.DeveloperEvaluation.Application.Handle.ProductsInSales.Create;
using System.Text.Json.Serialization;

namespace Ambev.DeveloperEvaluation.Api.Feature.Sales.Create;

public class CreateSalesRequest
{
    #region properties

    public Guid UserId { get; set; }
    public DateTime SaleDate { get; set; }

    [JsonIgnore]
    public decimal SaleAmmount { get; set; }
    public string SaleBranch { get; set; } = string.Empty;
    public List<CreateProductsInSalesCommand> Products { get; set; } = new List<CreateProductsInSalesCommand>();

    #endregion
}

