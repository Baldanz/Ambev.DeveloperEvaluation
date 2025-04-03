using Ambev.DeveloperEvaluation.Application.Handle.ProductsInCart.Create;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Api.Feature.ProductsInCart.Create;

/// <summary>
/// Profile for mapping between Application and API CreateProductsInCart responses
/// </summary>
public class CreateProductsInCartProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateProductsInCart feature
    /// </summary>
    public CreateProductsInCartProfile()
    {
        CreateMap<CreateProductsInCartRequest, CreateProductsInCartCommand>();
        CreateMap<CreateProductsInCartResult, CreateProductsInCartResponse>();
    }
}
