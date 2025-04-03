using Ambev.DeveloperEvaluation.Domain.Model;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Handle.User.Update;

public class UpdateUserProfile : Profile
{
    #region constructors

    /// <summary>
    /// CreateUserProfile constructor
    /// </summary>
    public UpdateUserProfile()
    {
        CreateMap<UpdateUserCommand, UserEntity>();
        CreateMap<UserEntity, UpdateUserResult>();
    }

    #endregion
}
