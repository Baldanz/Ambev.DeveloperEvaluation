using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handle.Cart.Get;
public record GetCartCommand : IRequest<GetCartResult>
{
    /// <summary>
    /// The unique identifier of the Cart to retrieve
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of GetCartCommand
    /// </summary>
    /// <param name="id">The ID of the Cart to retrieve</param>
    public GetCartCommand(Guid id)
    {
        Id = id;
    }
}