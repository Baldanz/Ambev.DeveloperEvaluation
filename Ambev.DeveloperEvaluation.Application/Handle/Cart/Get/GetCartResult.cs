using Ambev.DeveloperEvaluation.Application.Handle.ProductsInCart.Get;

namespace Ambev.DeveloperEvaluation.Application.Handle.Cart.Get;

public class GetCartResult
{
    #region properties

    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; private set; }
    public required List<GetProductsInCartResult> Products { get; set; } 
        = new List<GetProductsInCartResult>();

    #endregion
}