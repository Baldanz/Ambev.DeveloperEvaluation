using Ambev.DeveloperEvaluation.UoW.Interface;
using AutoMapper;
using MediatR;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Handle.Rating.Get;

public class GetRatingHandler : IRequestHandler<GetRatingCommand, GetRatingResult>
{
    private readonly IUoW _uow;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of GetRatingHandler
    /// </summary>
    /// <param name="RatingRepository">The Rating repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for GetRatingCommand</param>
    public GetRatingHandler(
        IUoW uow,
        IMapper mapper)
    {
        _uow = uow;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the GetRatingCommand request
    /// </summary>
    /// <param name="request">The GetRating command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Rating details if found</returns>
    public async Task<GetRatingResult> Handle(GetRatingCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetRatingValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var Rating = await _uow.RatingRepository.GetByIdAsync(request.Id, request.ProductId, cancellationToken);
        if (Rating == null)
            throw new KeyNotFoundException($"Rating with ID {request.Id} not found");

        return _mapper.Map<GetRatingResult>(Rating);
    }
}
