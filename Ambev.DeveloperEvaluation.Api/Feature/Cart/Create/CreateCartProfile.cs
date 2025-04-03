using Ambev.DeveloperEvaluation.Application.Handle.Cart.Create;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Api.Feature.Cart.Create;

/// <summary>
/// Profile for mapping between Application and API CreateCart responses
/// </summary>
public class CreateCartProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateCart feature
    /// </summary>
    public CreateCartProfile()
    {
        CreateMap<CreateCartRequest, CreateCartCommand>();
        CreateMap<CreateCartResult, CreateCartResponse>();
    }
}
