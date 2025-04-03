using Ambev.DeveloperEvaluation.Application.Handle.Product.Delete;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Api.Features.Product.Delete;

/// <summary>
/// Profile for mapping Delete feature requests to commands
/// </summary>
public class DeleteProductProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for Delete feature
    /// </summary>
    public DeleteProductProfile()
    {
        CreateMap<Guid, DeleteProductCommand>()
            .ConstructUsing(id => new DeleteProductCommand(id));
    }
}
