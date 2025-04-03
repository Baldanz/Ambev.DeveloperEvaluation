namespace Ambev.DeveloperEvaluation.WebApi.Features.ProductsInCart.Delete;

/// <summary>
/// Request model for deleting a ProductsInCart
/// </summary>
public class DeleteProductsInCartRequest
{
    /// <summary>
    /// The unique identifier of the ProductsInCart to delete
    /// </summary>
    public Guid CartId { get; set; }
    public Guid ProductId { get; set; }
}
