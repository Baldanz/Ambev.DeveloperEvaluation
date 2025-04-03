using Ambev.DeveloperEvaluation.Domain.Model;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Handle.ProductsInCart.Create;

public class CreateProductsInCartProfile : Profile
{
    #region constructors

    /// <summary>
    /// CreateProductsInCartProfile constructor
    /// </summary>
    public CreateProductsInCartProfile() 
    {
        CreateMap<CreateProductsInCartCommand, ProductsInCartEntity>();
        CreateMap<ProductsInCartEntity, CreateProductsInCartResult>();
    }

    #endregion
}
