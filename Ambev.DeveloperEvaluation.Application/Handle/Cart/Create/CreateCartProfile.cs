using Ambev.DeveloperEvaluation.Domain.Model;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Handle.Cart.Create;

public class CreateCartProfile : Profile
{
    #region constructors

    /// <summary>
    /// CreateCartProfile constructor
    /// </summary>
    public CreateCartProfile() 
    {
        CreateMap<CreateCartCommand, CartEntity>();
        CreateMap<CartEntity, CreateCartResult>();
    }

    #endregion
}
