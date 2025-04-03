using Ambev.DeveloperEvaluation.Application.Handle.ProductsInCart.Delete;
using Ambev.DeveloperEvaluation.WebApi.Features.Product.Delete;
using Ambev.DeveloperEvaluation.WebApi.Features.ProductsInCart.Delete;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Api.Features.ProductsInCart.Delete;

/// <summary>
/// Profile for mapping Delete feature requests to commands
/// </summary>
public class DeleteProductsInCartProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for Delete feature
    /// </summary>
    public DeleteProductsInCartProfile()
    {
        CreateMap<DeleteProductsInCartRequest, DeleteProductsInCartCommand>()
            .ConstructUsing(x => new DeleteProductsInCartCommand(x.CartId, x.ProductId));
    }
}
