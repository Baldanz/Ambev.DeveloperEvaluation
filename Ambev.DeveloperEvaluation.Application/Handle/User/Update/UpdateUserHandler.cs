using Ambev.DeveloperEvaluation.Common.Security.Interface;
using Ambev.DeveloperEvaluation.UoW.Interface;
using AutoMapper;
using FluentValidation;
using MediatR;


namespace Ambev.DeveloperEvaluation.Application.Handle.User.Update;

/// <summary>
/// Handler for processing UpdateUserCommand requests
/// </summary>
public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UpdateUserResult>
{
    private readonly IUoW _uow;
    private readonly IMapper _mapper;
    private readonly IPasswordEncryption _passwordEncryption;

    /// <summary>
    /// Initializes a new instance of UpdateUserHandler
    /// </summary>
    /// <param name="uow">The user repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for UpdateUserCommand</param>
    public UpdateUserHandler(IUoW uow, IMapper mapper, IPasswordEncryption passwordEncryption)
    {
        _uow = uow;
        _mapper = mapper;
        _passwordEncryption = passwordEncryption;
    }

    /// <summary>
    /// Handles the UpdateUserCommand request
    /// </summary>
    /// <param name="command">The UpdateUser command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created user details</returns>
    public async Task<UpdateUserResult> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var validator = new UpdateUserValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        var user = _mapper.Map<Domain.Model.UserEntity>(command);
        user.Password = _passwordEncryption.HashPassword(command.Password);

        var createdUser = await _uow.UserRepository.UpdateAsync(user, cancellationToken);
        var result = _mapper.Map<UpdateUserResult>(createdUser);
        return result;
    }
}
