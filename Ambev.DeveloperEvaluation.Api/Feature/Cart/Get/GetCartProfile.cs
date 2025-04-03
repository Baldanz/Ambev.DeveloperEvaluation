using Ambev.DeveloperEvaluation.Api.Feature.Cart.Get;
using Ambev.DeveloperEvaluation.Application.Handle.Cart.Get;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Api.Feature.Ratings.Feature.Cart.Get;

/// <summary>
/// Profile for mapping GetCart feature requests to commands
/// </summary>
public class GetCartProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetCart feature
    /// </summary>
    public GetCartProfile()
    {
        CreateMap<Guid, GetCartCommand>()
            .ConstructUsing(id => new GetCartCommand(id));
        CreateMap<GetListCartRequest, GetListCartCommand>().ReverseMap();
        CreateMap<GetCartResponse, GetCartResult>().ReverseMap();
    }
}
