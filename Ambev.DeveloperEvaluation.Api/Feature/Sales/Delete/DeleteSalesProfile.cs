using Ambev.DeveloperEvaluation.Application.Handle.Sales.Delete;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Api.Features.Sales.Delete;

/// <summary>
/// Profile for mapping Delete feature requests to commands
/// </summary>
public class DeleteSalesProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for Delete feature
    /// </summary>
    public DeleteSalesProfile()
    {
        CreateMap<Guid, DeleteSalesCommand>()
            .ConstructUsing(id => new DeleteSalesCommand(id));
    }
}
