using Ambev.DeveloperEvaluation.Domain.Model;
using Ambev.DeveloperEvaluation.UoW.Interface;
using AutoMapper;
using FluentValidation;
using MediatR;


namespace Ambev.DeveloperEvaluation.Application.Handle.ProductsInCart.Create;

/// <summary>
/// Handler for processing CreateProductsInCartCommand requests
/// </summary>
public class CreateProductsInCartHandler : IRequestHandler<CreateProductsInCartCommand, CreateProductsInCartResult>
{
    private readonly IUoW _uow;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of CreateProductsInCartHandler
    /// </summary>
    /// <param name="uow">The ProductsInCart repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for CreateProductsInCartCommand</param>
    public CreateProductsInCartHandler(IUoW uow, IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the CreateProductsInCartCommand request
    /// </summary>
    /// <param name="command">The CreateProductsInCart command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created product details</returns>
    public async Task<CreateProductsInCartResult> Handle(CreateProductsInCartCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateProductsInCartValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        //var existingProductsInCart = await _uow.ProductsInCartRepository.GetByIdAsync(command.Id, cancellationToken);
        //if (existingProductsInCart != null)
        //    throw new InvalidOperationException($"ProductsInCart { command.Id } already exists");

        var product = _mapper.Map<ProductsInCartEntity>(command);

        var createdProductsInCart = await _uow.ProductsInCartRepository.CreateAsync(product, cancellationToken);
        var result = _mapper.Map<CreateProductsInCartResult>(createdProductsInCart);
        return result;
    }
}
