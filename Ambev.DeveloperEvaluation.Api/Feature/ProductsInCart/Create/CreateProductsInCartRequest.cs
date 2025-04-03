using Ambev.DeveloperEvaluation.Application.Handle.Rating.Create;

namespace Ambev.DeveloperEvaluation.Api.Feature.ProductsInCart.Create;

/// <summary>
/// Represents a request to create a new ProductsInCart in the system.
/// </summary>
public class CreateProductsInCartRequest
{
    #region properties

    public Guid CartId {  get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }

    #endregion
}