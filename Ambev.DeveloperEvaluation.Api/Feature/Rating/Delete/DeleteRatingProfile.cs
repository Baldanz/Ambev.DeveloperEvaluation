using Ambev.DeveloperEvaluation.Application.Handle.Rating.Delete;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Api.Features.Rating.Delete;

/// <summary>
/// Profile for mapping Delete feature requests to commands
/// </summary>
public class DeleteRatingProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for Delete feature
    /// </summary>
    public DeleteRatingProfile()
    {
        CreateMap<Guid, DeleteRatingCommand>()
            .ConstructUsing(id => new DeleteRatingCommand(id));
    }
}
