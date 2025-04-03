using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handle.ProductsInCart.Get;
public record GetListProductsInCartCommand : IRequest<IEnumerable<GetProductsInCartResult>>
{
}