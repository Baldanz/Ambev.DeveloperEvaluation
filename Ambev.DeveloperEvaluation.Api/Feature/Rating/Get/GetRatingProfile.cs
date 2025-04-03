using Ambev.DeveloperEvaluation.Application.Handle.Rating.Get;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Api.Feature.Ratings.Feature.Ratings.Get;

/// <summary>
/// Profile for mapping GetRating feature requests to commands
/// </summary>
public class GetRatingProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetRating feature
    /// </summary>
    public GetRatingProfile()
    {
        CreateMap<GetRatingRequest, GetRatingCommand>();
        CreateMap<GetRatingResponse, GetRatingResult>().ReverseMap();
    }
}