using Ambev.DeveloperEvaluation.Application.Handle.User.Delete;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.User.Delete;

/// <summary>
/// Profile for mapping DeleteUser feature requests to commands
/// </summary>
public class DeleteUserProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for DeleteUser feature
    /// </summary>
    public DeleteUserProfile()
    {
        CreateMap<Guid, DeleteUserCommand>()
            .ConstructUsing(id => new DeleteUserCommand(id));
    }
}
