using Ambev.DeveloperEvaluation.UoW.Interface;
using AutoMapper;
using MediatR;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Handle.Sales.Get;

public class GetSalesHandler : IRequestHandler<GetSalesCommand, GetSalesResult>
{
    private readonly IUoW _uow;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of GetSalesHandler
    /// </summary>
    /// <param name="SalesRepository">The Sales repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for GetSalesCommand</param>
    public GetSalesHandler(
        IUoW uow,
        IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the GetSalesCommand request
    /// </summary>
    /// <param name="request">The GetSales command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Sales details if found</returns>
    public async Task<GetSalesResult> Handle(GetSalesCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetSalesValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var Sales = await _uow.SalesRepository.GetByIdAsync(request.Id, cancellationToken);
        if (Sales == null)
            throw new KeyNotFoundException($"Sales with ID {request.Id} not found");

        return _mapper.Map<GetSalesResult>(Sales);
    }
}
