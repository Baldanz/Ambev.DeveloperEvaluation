using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handle.Rating.Delete;

public record DeleteRatingCommand : IRequest<DeleteRatingResponse>
{
    /// <summary>
    /// The unique identifier of the product to delete
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of DeleteRatingCommand
    /// </summary>
    /// <param name="id">The ID of the product to delete</param>
    public DeleteRatingCommand(Guid id)
    {
        Id = id;
    }
}
