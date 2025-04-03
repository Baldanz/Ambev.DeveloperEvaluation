using Ambev.DeveloperEvaluation.Domain.Model;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Handle.Rating.Get;

public class GetRatingProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetRating operation
    /// </summary>
    public GetRatingProfile()
    {
        CreateMap<RatingEntity, GetRatingResult>();
    }
}