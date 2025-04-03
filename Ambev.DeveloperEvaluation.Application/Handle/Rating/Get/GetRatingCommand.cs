using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handle.Rating.Get;
public record GetRatingCommand : IRequest<GetRatingResult>
{
    /// <summary>
    /// The unique identifier of the Rating to retrieve
    /// </summary>
    public Guid? Id { get; }
    public Guid? ProductId { get; }

    /// <summary>
    /// Initializes a new instance of GetRatingCommand
    /// </summary>
    /// <param name="id">The ID of the Rating to retrieve</param>
    public GetRatingCommand(Guid id, Guid? productId)
    {
        Id = id;
        ProductId = productId;
    }
}