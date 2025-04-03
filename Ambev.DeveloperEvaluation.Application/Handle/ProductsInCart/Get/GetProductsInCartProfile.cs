using Ambev.DeveloperEvaluation.Domain.Model;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Handle.ProductsInCart.Get;

public class GetProductsInCartProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetProductsInCart operation
    /// </summary>
    public GetProductsInCartProfile()
    {
        CreateMap<ProductsInCartEntity, GetProductsInCartResult>();
    }
}