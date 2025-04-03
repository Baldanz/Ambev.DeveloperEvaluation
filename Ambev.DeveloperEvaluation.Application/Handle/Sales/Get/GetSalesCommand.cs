using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handle.Sales.Get;
public record GetSalesCommand : IRequest<GetSalesResult>
{
    /// <summary>
    /// The unique identifier of the Sales to retrieve
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of GetSalesCommand
    /// </summary>
    /// <param name="id">The ID of the Sales to retrieve</param>
    public GetSalesCommand(Guid id)
    {
        Id = id;
    }
}