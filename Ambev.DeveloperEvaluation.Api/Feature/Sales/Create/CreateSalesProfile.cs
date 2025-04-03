using Ambev.DeveloperEvaluation.Application.Handle.Sales.Create;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Api.Feature.Sales.Create;

/// <summary>
/// Profile for mapping between Application and API CreateSales responses
/// </summary>
public class CreateSalesProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateSales feature
    /// </summary>
    public CreateSalesProfile()
    {
        CreateMap<CreateSalesRequest, CreateSalesCommand>();
        CreateMap<CreateSalesResult, CreateSalesResponse>();
    }
}
