using Ambev.DeveloperEvaluation.Domain.Model;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Handle.ProductsInSales.Create;

public class CreateProductsInSalesProfile : Profile
{
    #region constructors

    /// <summary>
    /// CreateProductsInSalesProfile constructor
    /// </summary>
    public CreateProductsInSalesProfile() 
    {
        CreateMap<CreateProductsInSalesCommand, ProductsInSalesEntity>();
        CreateMap<ProductsInSalesEntity, CreateProductsInSalesResult>();
    }

    #endregion
}
