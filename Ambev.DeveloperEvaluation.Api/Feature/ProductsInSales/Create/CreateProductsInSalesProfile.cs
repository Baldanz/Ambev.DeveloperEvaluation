using Ambev.DeveloperEvaluation.Application.Handle.ProductsInSales.Create;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Api.Feature.ProductsInSales.Create;

/// <summary>
/// Profile for mapping between Application and API CreateProductsInSales responses
/// </summary>
public class CreateProductsInSalesProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateProductsInSales feature
    /// </summary>
    public CreateProductsInSalesProfile()
    {
        CreateMap<CreateProductsInSalesRequest, CreateProductsInSalesCommand>();
        CreateMap<CreateProductsInSalesResult, CreateProductsInSalesResponse>();
    }
}
