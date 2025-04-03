using Ambev.DeveloperEvaluation.Domain.Model;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Handle.Sales.Get;

public class GetSalesProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetSales operation
    /// </summary>
    public GetSalesProfile()
    {
        CreateMap<SalesEntity, GetSalesResult>();
    }
}