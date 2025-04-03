using Ambev.DeveloperEvaluation.Domain.Model;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Handle.Cart.Get;

public class GetCartProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetCart operation
    /// </summary>
    public GetCartProfile()
    {
        CreateMap<CartEntity, GetCartResult>();
    }
}