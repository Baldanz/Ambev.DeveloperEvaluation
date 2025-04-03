using Ambev.DeveloperEvaluation.Api.Feature.Sales.Get;
using Ambev.DeveloperEvaluation.Application.Handle.Sales.Get;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Api.Feature.Ratings.Feature.Sales.Get;

/// <summary>
/// Profile for mapping GetSales feature requests to commands
/// </summary>
public class GetSalesProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetSales feature
    /// </summary>
    public GetSalesProfile()
    {
        CreateMap<Guid, GetSalesCommand>()
            .ConstructUsing(id => new GetSalesCommand(id));
        CreateMap<GetListSalesRequest, GetListSalesCommand>().ReverseMap();
        CreateMap<GetSalesResponse, GetSalesResult>().ReverseMap();
    }
}
