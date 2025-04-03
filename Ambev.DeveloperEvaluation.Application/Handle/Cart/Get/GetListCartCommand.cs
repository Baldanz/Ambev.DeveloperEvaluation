using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handle.Cart.Get;
public record GetListCartCommand : IRequest<IEnumerable<GetCartResult>>
{
}