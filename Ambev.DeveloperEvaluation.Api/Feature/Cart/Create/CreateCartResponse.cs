using Ambev.DeveloperEvaluation.Api.Feature.ProductsInCart.Create;

namespace Ambev.DeveloperEvaluation.Api.Feature.Cart.Create;

public class CreateCartResponse
{
    #region properties

    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public required List<CreateProductsInCartResponse> Products { get; set; } 
        = new List<CreateProductsInCartResponse>();

    #endregion
}
