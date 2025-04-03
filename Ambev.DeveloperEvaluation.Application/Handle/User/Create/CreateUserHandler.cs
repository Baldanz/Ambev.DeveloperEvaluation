using Ambev.DeveloperEvaluation.Common.Security.Interface;
using Ambev.DeveloperEvaluation.UoW.Interface;
using AutoMapper;
using FluentValidation;
using MediatR;


namespace Ambev.DeveloperEvaluation.Application.Handle.User.Create;

/// <summary>
/// Handler for processing CreateUserCommand requests
/// </summary>
public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserResult>
{
    private readonly IUoW _uow;
    private readonly IMapper _mapper;
    private readonly IPasswordEncryption _passwordEncryption;

    /// <summary>
    /// Initializes a new instance of CreateUserHandler
    /// </summary>
    /// <param name="uow">The user repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for CreateUserCommand</param>
    public CreateUserHandler(IUoW uow, IMapper mapper, IPasswordEncryption passwordEncryption)
    {
        _uow = uow;
        _mapper = mapper;
        _passwordEncryption = passwordEncryption;
    }

    /// <summary>
    /// Handles the CreateUserCommand request
    /// </summary>
    /// <param name="command">The CreateUser command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created user details</returns>
    public async Task<CreateUserResult> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateUserValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var existingUser = await _uow.UserRepository.GetByEmailAsync(command.Email, cancellationToken);
        if (existingUser != null)
            throw new InvalidOperationException($"User with email {command.Email} already exists");

        var user = _mapper.Map<Domain.Model.UserEntity>(command);
        user.Password = _passwordEncryption.HashPassword(command.Password);

        var createdUser = await _uow.UserRepository.CreateAsync(user, cancellationToken);
        var result = _mapper.Map<CreateUserResult>(createdUser);
        return result;
    }
}
