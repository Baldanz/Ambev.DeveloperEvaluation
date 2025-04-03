using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handle.ProductsInCart.Delete;

public record DeleteProductsInCartCommand : IRequest<DeleteProductsInCartResponse>
{
    /// <summary>
    /// The unique identifier of the product to delete
    /// </summary>
    public Guid CartId { get; }
    public Guid ProductId { get; }

    /// <summary>
    /// Initializes a new instance of DeleteProductsInCartCommand
    /// </summary>
    /// <param name="id">The ID of the product to delete</param>
    public DeleteProductsInCartCommand(Guid cartId, Guid productId)
    {
        CartId = cartId;
        ProductId = productId;
    }
}
