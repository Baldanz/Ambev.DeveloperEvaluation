using Ambev.DeveloperEvaluation.UoW.Interface;
using AutoMapper;
using MediatR;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Handle.ProductsInSales.Get;

public class GetProductsInSalesHandler : IRequestHandler<GetProductsInSalesCommand, GetProductsInSalesResult>
{
    private readonly IUoW _uow;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of GetProductsInSalesHandler
    /// </summary>
    /// <param name="ProductsInSalesRepository">The ProductsInSales repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for GetProductsInSalesCommand</param>
    public GetProductsInSalesHandler(
        IUoW uow,
        IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the GetProductsInSalesCommand request
    /// </summary>
    /// <param name="request">The GetProductsInSales command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The ProductsInSales details if found</returns>
    public async Task<GetProductsInSalesResult> Handle(GetProductsInSalesCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetProductsInSalesValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var ProductsInSales = await _uow.ProductsInSalesRepository.GetByIdAsync(request.SaleId, request.ProductId, cancellationToken);
        if (ProductsInSales == null)
            throw new KeyNotFoundException($"Sale with ID {request.SaleId} and Product with ID {request.ProductId} not found");

        return _mapper.Map<GetProductsInSalesResult>(ProductsInSales);
    }
}
