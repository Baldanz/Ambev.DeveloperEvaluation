using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handle.ProductsInSales.Get;
public record GetListProductsInSalesCommand : IRequest<IEnumerable<GetProductsInSalesResult>>
{
}