using Ambev.DeveloperEvaluation.Api.Feature.ProductsInCart.Create;
using Ambev.DeveloperEvaluation.Api.Feature.ProductsInCart.Get;
using Ambev.DeveloperEvaluation.Application.Handle.ProductsInCart.Get;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Api.Feature.Ratings.Feature.ProductsInCart.Get;

/// <summary>
/// Profile for mapping GetProductsInCart feature requests to commands
/// </summary>
public class GetProductsInCartProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetProductsInCart feature
    /// </summary>
    public GetProductsInCartProfile()
    {
        CreateMap<CreateProductsInCartRequest, GetProductsInCartCommand>()
            .ConstructUsing(x => new GetProductsInCartCommand(x.CartId, x.ProductId));
        CreateMap<GetListProductsInCartRequest, GetListProductsInCartCommand>().ReverseMap();
        CreateMap<GetProductsInCartResponse, GetProductsInCartResult>().ReverseMap();
    }
}
