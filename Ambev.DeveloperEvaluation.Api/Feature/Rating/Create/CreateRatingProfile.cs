using Ambev.DeveloperEvaluation.Application.Handle.Rating.Create;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Api.Feature.Rating.Create;

/// <summary>
/// Profile for mapping between Application and API CreateRating responses
/// </summary>
public class CreateRatingProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateRating feature
    /// </summary>
    public CreateRatingProfile()
    {
        CreateMap<CreateRatingRequest, CreateRatingCommand>();
        CreateMap<CreateRatingResult, CreateRatingResponse>();
    }
}
