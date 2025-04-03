using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handle.Sales.Get;
public record GetListSalesCommand : IRequest<IEnumerable<GetSalesResult>>
{
}