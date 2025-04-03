using Ambev.DeveloperEvaluation.Application.Handle.Product.Create;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Api.Feature.Product.Create;

/// <summary>
/// Profile for mapping between Application and API CreateProduct responses
/// </summary>
public class CreateProductProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateProduct feature
    /// </summary>
    public CreateProductProfile()
    {
        CreateMap<CreateProductRequest, CreateProductCommand>();
        CreateMap<CreateProductResult, CreateProductResponse>();
    }
}
