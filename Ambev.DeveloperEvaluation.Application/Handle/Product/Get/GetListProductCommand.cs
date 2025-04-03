using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handle.Product.Get;
public record GetListProductCommand : IRequest<IEnumerable<GetProductResult>>
{
}