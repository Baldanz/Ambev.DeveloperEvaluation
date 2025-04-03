using Ambev.DeveloperEvaluation.Domain.Model;
using Ambev.DeveloperEvaluation.UoW.Interface;
using AutoMapper;
using FluentValidation;
using MediatR;


namespace Ambev.DeveloperEvaluation.Application.Handle.Sales.Create;

/// <summary>
/// Handler for processing CreateSalesCommand requests
/// </summary>
public class CreateSalesHandler : IRequestHandler<CreateSalesCommand, CreateSalesResult>
{
    private readonly IUoW _uow;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of CreateSalesHandler
    /// </summary>
    /// <param name="uow">The Sales repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for CreateSalesCommand</param>
    public CreateSalesHandler(IUoW uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the CreateSalesCommand request
    /// </summary>
    /// <param name="command">The CreateSales command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created product details</returns>
    public async Task<CreateSalesResult> Handle(CreateSalesCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateSalesValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        //var existingSales = await _uow.SalesRepository.GetByIdAsync(command.Id, cancellationToken);
        //if (existingSales != null)
        //    throw new InvalidOperationException($"Sales { command.Id } already exists");

        var product = _mapper.Map<SalesEntity>(command);

        var createdSales = await _uow.SalesRepository.CreateAsync(product, cancellationToken);
        var result = _mapper.Map<CreateSalesResult>(createdSales);
        return result;
    }
}
