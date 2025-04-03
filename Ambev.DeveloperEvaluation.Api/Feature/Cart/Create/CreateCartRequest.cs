using Ambev.DeveloperEvaluation.Application.Handle.ProductsInCart.Create;
using Ambev.DeveloperEvaluation.Application.Handle.Rating.Create;

namespace Ambev.DeveloperEvaluation.Api.Feature.Cart.Create;

/// <summary>
/// Represents a request to create a new Cart in the system.
/// </summary>
public class CreateCartRequest
{
    #region properties

    public Guid UserId { get; set; }
    public List<CreateProductsInCartCommand> Products { get; set; } = new List<CreateProductsInCartCommand>();

    #endregion
}

