using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handle.ProductsInSales.Get;
public record GetProductsInSalesCommand : IRequest<GetProductsInSalesResult>
{
    public Guid SaleId { get; }
    public Guid ProductId { get; }

    public GetProductsInSalesCommand(Guid saleId, Guid productId)
    {
        SaleId = saleId;
        ProductId = productId;
    }
}