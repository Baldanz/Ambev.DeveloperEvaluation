using Ambev.DeveloperEvaluation.Api.Feature.User.Get;
using Ambev.DeveloperEvaluation.Application.Handle.User.Get;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Api.Features.User.Get;

/// <summary>
/// Profile for mapping GetUser feature requests to commands
/// </summary>
public class GetUserProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetUser feature
    /// </summary>
    public GetUserProfile()
    {
        CreateMap<Guid, GetUserCommand>()
            .ConstructUsing(id => new GetUserCommand(id));
        CreateMap<GetListUserRequest, GetListUserCommand>().ReverseMap();
        CreateMap<GetUserResponse, GetUserResult>().ReverseMap();
    }
}
