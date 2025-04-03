using Ambev.DeveloperEvaluation.Api.Feature.ProductsInSales.Create;

namespace Ambev.DeveloperEvaluation.Api.Feature.Sales.Create;

public class CreateSalesResponse
{
    #region properties

    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime SaleDate { get; set; }
    public required List<CreateProductsInSalesResponse> Products { get; set; } 
        = new List<CreateProductsInSalesResponse>();

    #endregion
}
