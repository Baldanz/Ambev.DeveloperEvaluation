using Ambev.DeveloperEvaluation.Domain.Model;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Handle.ProductsInSales.Get;

public class GetProductsInSalesProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetProductsInSales operation
    /// </summary>
    public GetProductsInSalesProfile()
    {
        CreateMap<ProductsInSalesEntity, GetProductsInSalesResult>();
    }
}