using Ambev.DeveloperEvaluation.Application.Handle.ProductsInSales.Delete;
using Ambev.DeveloperEvaluation.WebApi.Features.Product.Delete;
using Ambev.DeveloperEvaluation.WebApi.Features.ProductsInSales.Delete;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Api.Features.ProductsInSales.Delete;

/// <summary>
/// Profile for mapping Delete feature requests to commands
/// </summary>
public class DeleteProductsInSalesProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for Delete feature
    /// </summary>
    public DeleteProductsInSalesProfile()
    {
        CreateMap<DeleteProductsInSalesRequest, DeleteProductsInSalesCommand>()
            .ConstructUsing(x => new DeleteProductsInSalesCommand(x.SaleId, x.ProductId));
    }
}
