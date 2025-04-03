using Ambev.DeveloperEvaluation.Common.Security.Interface;
using Ambev.DeveloperEvaluation.Domain.Specifications;
using Ambev.DeveloperEvaluation.ORM.Repository.Interface;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handle.Auth.AuthenticateUser;

public class AuthenticateUserHandler : IRequestHandler<AuthenticateUserCommand, AuthenticateUserResult>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordEncryption _passwordEncryption;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticateUserHandler(
        IUserRepository userRepository,
        IPasswordEncryption passwordEncryption,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _passwordEncryption = passwordEncryption;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<AuthenticateUserResult> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (user == null || !_passwordEncryption.VerifyPassword(request.Password, user.Password))
        {
            throw new UnauthorizedAccessException("Invalid credentials");
        }

        var activeUserSpec = new ActiveUserSpecification();
        if (!activeUserSpec.IsSatisfiedBy(user))
        {
            throw new UnauthorizedAccessException("User is not active");
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticateUserResult
        {
            Token = token,
            Email = user.Email,
            Name = user.UserName,
            Role = user.Role.ToString()
        };
    }
}