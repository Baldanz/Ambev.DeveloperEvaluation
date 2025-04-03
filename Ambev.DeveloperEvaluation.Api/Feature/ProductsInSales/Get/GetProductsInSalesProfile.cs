using Ambev.DeveloperEvaluation.Api.Feature.ProductsInSales.Create;
using Ambev.DeveloperEvaluation.Api.Feature.ProductsInSales.Get;
using Ambev.DeveloperEvaluation.Application.Handle.ProductsInSales.Get;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Api.Feature.Ratings.Feature.ProductsInSales.Get;

/// <summary>
/// Profile for mapping GetProductsInSales feature requests to commands
/// </summary>
public class GetProductsInSalesProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetProductsInSales feature
    /// </summary>
    public GetProductsInSalesProfile()
    {
        CreateMap<CreateProductsInSalesRequest, GetProductsInSalesCommand>()
            .ConstructUsing(x => new GetProductsInSalesCommand(x.SaleId, x.ProductId));
        CreateMap<GetListProductsInSalesRequest, GetListProductsInSalesCommand>().ReverseMap();
        CreateMap<GetProductsInSalesResponse, GetProductsInSalesResult>().ReverseMap();
    }
}
