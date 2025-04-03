using Ambev.DeveloperEvaluation.Domain.Model;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Handle.Rating.Create;

public class CreateRatingProfile : Profile
{
    #region constructors

    /// <summary>
    /// CreateRatingProfile constructor
    /// </summary>
    public CreateRatingProfile() 
    {
        CreateMap<CreateRatingCommand, RatingEntity>();
        CreateMap<RatingEntity, CreateRatingResult>();
    }

    #endregion
}
