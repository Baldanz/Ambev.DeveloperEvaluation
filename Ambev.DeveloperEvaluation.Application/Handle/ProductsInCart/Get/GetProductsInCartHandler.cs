using Ambev.DeveloperEvaluation.UoW.Interface;
using AutoMapper;
using MediatR;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Handle.ProductsInCart.Get;

public class GetProductsInCartHandler : IRequestHandler<GetProductsInCartCommand, GetProductsInCartResult>
{
    private readonly IUoW _uow;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of GetProductsInCartHandler
    /// </summary>
    /// <param name="ProductsInCartRepository">The ProductsInCart repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for GetProductsInCartCommand</param>
    public GetProductsInCartHandler(
        IUoW uow,
        IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the GetProductsInCartCommand request
    /// </summary>
    /// <param name="request">The GetProductsInCart command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The ProductsInCart details if found</returns>
    public async Task<GetProductsInCartResult> Handle(GetProductsInCartCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetProductsInCartValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var ProductsInCart = await _uow.ProductsInCartRepository.GetByIdAsync(request.CartId, request.ProductId, cancellationToken);
        if (ProductsInCart == null)
            throw new KeyNotFoundException($"Cart with ID {request.CartId} and Product with ID {request.ProductId} not found");

        return _mapper.Map<GetProductsInCartResult>(ProductsInCart);
    }
}
