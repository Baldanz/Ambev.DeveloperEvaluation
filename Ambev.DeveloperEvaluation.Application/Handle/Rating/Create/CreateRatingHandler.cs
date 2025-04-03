using Ambev.DeveloperEvaluation.Common.Security.Interface;
using Ambev.DeveloperEvaluation.Domain.Model;
using Ambev.DeveloperEvaluation.UoW.Interface;
using AutoMapper;
using FluentValidation;
using MediatR;


namespace Ambev.DeveloperEvaluation.Application.Handle.Rating.Create;

/// <summary>
/// Handler for processing CreateRatingCommand requests
/// </summary>
public class CreateRatingHandler : IRequestHandler<CreateRatingCommand, CreateRatingResult>
{
    private readonly IUoW _uow;
    private readonly IMapper _mapper;
    private readonly IPasswordEncryption _passwordEncryption;

    /// <summary>
    /// Initializes a new instance of CreateRatingHandler
    /// </summary>
    /// <param name="uow">The Cart repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for CreateRatingCommand</param>
    public CreateRatingHandler(IUoW uow, IMapper mapper, IPasswordEncryption passwordEncryption)
    {
        _uow = uow;
        _mapper = mapper;
        _passwordEncryption = passwordEncryption;
    }

    /// <summary>
    /// Handles the CreateRatingCommand request
    /// </summary>
    /// <param name="command">The CreateRating command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created product details</returns>
    public async Task<CreateRatingResult> Handle(CreateRatingCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateRatingValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var product = _mapper.Map<RatingEntity>(command);

        var createdCart = await _uow.RatingRepository.CreateAsync(product, cancellationToken);
        var result = _mapper.Map<CreateRatingResult>(createdCart);
        return result;
    }
}
