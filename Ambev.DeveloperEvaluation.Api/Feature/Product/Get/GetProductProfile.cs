using Ambev.DeveloperEvaluation.Api.Feature.Product.Get;
using Ambev.DeveloperEvaluation.Application.Handle.Product.Get;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Api.Feature.Ratings.Feature.Product.Get;

/// <summary>
/// Profile for mapping GetProduct feature requests to commands
/// </summary>
public class GetProductProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetProduct feature
    /// </summary>
    public GetProductProfile()
    {
        CreateMap<Guid, GetProductCommand>()
            .ConstructUsing(id => new GetProductCommand(id));
        CreateMap<GetListProductRequest, GetListProductCommand>().ReverseMap();
        CreateMap<GetProductResponse, GetProductResult>().ReverseMap();
    }
}
