using Ambev.DeveloperEvaluation.Domain.Model;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Handle.Sales.Create;

public class CreateSalesProfile : Profile
{
    #region constructors

    /// <summary>
    /// CreateSalesProfile constructor
    /// </summary>
    public CreateSalesProfile() 
    {
        CreateMap<CreateSalesCommand, SalesEntity>();
        CreateMap<SalesEntity, CreateSalesResult>();
    }

    #endregion
}
