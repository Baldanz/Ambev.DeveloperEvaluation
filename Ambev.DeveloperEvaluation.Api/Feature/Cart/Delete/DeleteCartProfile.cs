using Ambev.DeveloperEvaluation.Application.Handle.Cart.Delete;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Api.Features.Cart.Delete;

/// <summary>
/// Profile for mapping Delete feature requests to commands
/// </summary>
public class DeleteCartProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for Delete feature
    /// </summary>
    public DeleteCartProfile()
    {
        CreateMap<Guid, DeleteCartCommand>()
            .ConstructUsing(id => new DeleteCartCommand(id));
    }
}
