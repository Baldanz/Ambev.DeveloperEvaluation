using Ambev.DeveloperEvaluation.Api.Feature.Ratings.Feature.ProductsInCart.Get;

namespace Ambev.DeveloperEvaluation.Api.Feature.Ratings.Feature.Cart.Get;

/// <summary>
/// API response model for GetCart operation
/// </summary>
public class GetCartResponse
{
    #region properties

    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; private set; }
    public required List<GetProductsInCartResponse> Products { get; set; } 
        = new List<GetProductsInCartResponse>();

    #endregion
}
