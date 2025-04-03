using Ambev.DeveloperEvaluation.Domain.Model;
using Ambev.DeveloperEvaluation.UoW.Interface;
using AutoMapper;
using FluentValidation;
using MediatR;


namespace Ambev.DeveloperEvaluation.Application.Handle.ProductsInSales.Create;

/// <summary>
/// Handler for processing CreateProductsInSalesCommand requests
/// </summary>
public class CreateProductsInSalesHandler : IRequestHandler<CreateProductsInSalesCommand, CreateProductsInSalesResult>
{
    private readonly IUoW _uow;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of CreateProductsInSalesHandler
    /// </summary>
    /// <param name="uow">The ProductsInSales repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for CreateProductsInSalesCommand</param>
    public CreateProductsInSalesHandler(IUoW uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the CreateProductsInSalesCommand request
    /// </summary>
    /// <param name="command">The CreateProductsInSales command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created product details</returns>
    public async Task<CreateProductsInSalesResult> Handle(CreateProductsInSalesCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateProductsInSalesValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        //var existingProductsInSales = await _uow.ProductsInSalesRepository.GetByIdAsync(command.Id, cancellationToken);
        //if (existingProductsInSales != null)
        //    throw new InvalidOperationException($"ProductsInSales { command.Id } already exists");

        var product = _mapper.Map<ProductsInSalesEntity>(command);

        var createdProductsInSales = await _uow.ProductsInSalesRepository.CreateAsync(product, cancellationToken);
        var result = _mapper.Map<CreateProductsInSalesResult>(createdProductsInSales);
        return result;
    }
}
