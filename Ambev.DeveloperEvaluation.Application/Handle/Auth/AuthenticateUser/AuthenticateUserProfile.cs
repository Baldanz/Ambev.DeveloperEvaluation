using Ambev.DeveloperEvaluation.Domain.Model;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Handle.Auth.AuthenticateUser;

public sealed class AuthenticateUserProfile : Profile
{
    #region constructors

    public AuthenticateUserProfile()
    {
        CreateMap<UserEntity, AuthenticateUserResult>()
            .ForMember(dest => dest.Token, opt => opt.Ignore())
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()));
    }

    #endregion
}