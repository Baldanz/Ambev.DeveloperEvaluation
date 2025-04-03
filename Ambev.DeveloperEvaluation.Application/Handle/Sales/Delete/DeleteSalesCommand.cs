using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handle.Sales.Delete;

public record DeleteSalesCommand : IRequest<DeleteSalesResponse>
{
    public Guid Id { get; }

    public DeleteSalesCommand(Guid id)
    {
        Id = id;
    }
}
