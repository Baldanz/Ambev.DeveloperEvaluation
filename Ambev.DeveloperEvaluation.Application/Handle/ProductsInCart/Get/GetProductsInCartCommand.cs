using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handle.ProductsInCart.Get;
public record GetProductsInCartCommand : IRequest<GetProductsInCartResult>
{
    /// <summary>
    /// The unique identifier of the ProductsInCart to retrieve
    /// </summary>
    public Guid CartId { get; }
    public Guid ProductId { get; }

    /// <summary>
    /// Initializes a new instance of GetProductsInCartCommand
    /// </summary>
    /// <param name="cartId">The ID of the Cart to retrieve</param>
    public GetProductsInCartCommand(Guid cartId, Guid productId)
    {
        CartId = cartId;
        ProductId = productId;
    }
}