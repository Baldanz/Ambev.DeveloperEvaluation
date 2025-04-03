using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handle.ProductsInSales.Delete;

public record DeleteProductsInSalesCommand : IRequest<DeleteProductsInSalesResponse>
{
    public Guid SaleId { get; }
    public Guid ProductId { get; }
    public DeleteProductsInSalesCommand(Guid cartId, Guid productId)
    {
        SaleId = cartId;
        ProductId = productId;
    }
}
