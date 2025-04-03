namespace Ambev.DeveloperEvaluation.Api.Feature.Feature.ProductsInCart.Get;

/// <summary>
/// Request model for getting a user by ID
/// </summary>
public class GetProductsInCartRequest
{
    #region properties

    public Guid CartId { get; set; }
    public Guid ProductId { get; set; }

    #endregion
}
