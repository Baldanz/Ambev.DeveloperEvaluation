using Ambev.DeveloperEvaluation.Domain.Model;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Handle.User.Create;

public class CreateUserProfile : Profile
{
    #region constructors

    /// <summary>
    /// CreateUserProfile constructor
    /// </summary>
    public CreateUserProfile()
    {
        CreateMap<CreateUserCommand, UserEntity>();
        CreateMap<UserEntity, CreateUserResult>();
    }

    #endregion
}
