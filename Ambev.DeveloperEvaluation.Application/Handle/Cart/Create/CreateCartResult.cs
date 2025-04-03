using Ambev.DeveloperEvaluation.Application.Handle.ProductsInCart.Create;

namespace Ambev.DeveloperEvaluation.Application.Handle.Cart.Create;

public class CreateCartResult
{
    #region properties
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public required List<CreateProductsInCartResult> Products { get; set; } = new List<CreateProductsInCartResult>();

    #endregion
}
