using Ambev.DeveloperEvaluation.Application.Handle.Auth.AuthenticateUser;
using Ambev.DeveloperEvaluation.Domain.Model;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Api.Feature.Auth.AuthenticateUserFeature;

public sealed class AuthenticateUserProfile : Profile
{
    #region constructors

    public AuthenticateUserProfile()
    {
        CreateMap<UserEntity, AuthenticateUserResponse>()
            .ForMember(dest => dest.Token, opt => opt.Ignore())
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()));
        CreateMap<AuthenticateUserRequest, AuthenticateUserCommand>().ReverseMap();
        CreateMap< AuthenticateUserResult, AuthenticateUserResponse>().ReverseMap();
    }

    #endregion
}
