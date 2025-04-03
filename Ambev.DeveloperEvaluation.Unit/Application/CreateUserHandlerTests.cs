using Ambev.DeveloperEvaluation.Application.Handle.User.Create;
using Ambev.DeveloperEvaluation.Common.Security.Interface;
using Ambev.DeveloperEvaluation.Domain.Model;
using Ambev.DeveloperEvaluation.Unit.Domain;
using Ambev.DeveloperEvaluation.UoW.Interface;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application;

/// <summary>
/// Contains unit tests for the <see cref="CreateUserHandler"/> class.
/// </summary>
public class CreateUserHandlerTests
{
    private readonly IUoW _uow;
    private readonly IMapper _mapper;
    private readonly IPasswordEncryption _passwordEncryption;
    private readonly CreateUserHandler _handler;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateUserHandlerTests"/> class.
    /// Sets up the test dependencies and creates fake data generators.
    /// </summary>
    public CreateUserHandlerTests()
    {
        _uow = Substitute.For<IUoW>();
        _mapper = Substitute.For<IMapper>();
        _passwordEncryption = Substitute.For<IPasswordEncryption>();
        _handler = new CreateUserHandler(_uow, _mapper, _passwordEncryption);
    }

    /// <summary>
    /// Tests that a valid user creation request is handled successfully.
    /// </summary>
    [Fact(DisplayName = "Given valid user data When creating user Then returns success response")]
    public async Task Handle_ValidRequest_ReturnsSuccessResponse()
    {
        // Given
        var command = CreateUserHandlerTestData.GenerateValidCommand();
        var user = new UserEntity
        {
            Id = Guid.NewGuid(),
            UserName = command.UserName,
            Password = command.Password,
            Email = command.Email,
            Phone = command.Phone,
            Status = command.Status,
            Role = command.Role
        };

        var result = new CreateUserResult
        {
            Id = user.Id,
        };


        _mapper.Map<UserEntity>(command).Returns(user);
        _mapper.Map<CreateUserResult>(user).Returns(result);

        _uow.UserRepository.CreateAsync(Arg.Any<UserEntity>(), Arg.Any<CancellationToken>())
            .Returns(user);
        _passwordEncryption.HashPassword(Arg.Any<string>()).Returns("hashedPassword");

        // When
        var createUserResult = await _handler.Handle(command, CancellationToken.None);

        // Then
        createUserResult.Should().NotBeNull();
        createUserResult.Id.Should().Be(user.Id);
        await _uow.Received(1).UserRepository.CreateAsync(Arg.Any<UserEntity>(), Arg.Any<CancellationToken>());
    }

    /// <summary>
    /// Tests that an invalid user creation request throws a validation exception.
    /// </summary>
    [Fact(DisplayName = "Given invalid user data When creating user Then throws validation exception")]
    public async Task Handle_InvalidRequest_ThrowsValidationException()
    {
        // Given
        var command = new CreateUserCommand(); // Empty command will fail validation

        // When
        var act = () => _handler.Handle(command, CancellationToken.None);

        // Then
        await act.Should().ThrowAsync<FluentValidation.ValidationException>();
    }

    /// <summary>
    /// Tests that the password is hashed before saving the user.
    /// </summary>
    [Fact(DisplayName = "Given user creation request When handling Then password is hashed")]
    public async Task Handle_ValidRequest_HashesPassword()
    {
        // Given
        var command = CreateUserHandlerTestData.GenerateValidCommand();
        var originalPassword = command.Password;
        const string hashedPassword = "h@shedPassw0rd";
        var user = new UserEntity
        {
            Id = Guid.NewGuid(),
            UserName = command.UserName,
            Password = command.Password,
            Email = command.Email,
            Phone = command.Phone,
            Status = command.Status,
            Role = command.Role
        };

        _mapper.Map<UserEntity>(command).Returns(user);
        _uow.UserRepository.CreateAsync(Arg.Any<UserEntity>(), Arg.Any<CancellationToken>())
            .Returns(user);
        _passwordEncryption.HashPassword(originalPassword).Returns(hashedPassword);

        // When
        await _handler.Handle(command, CancellationToken.None);

        // Then
        _passwordEncryption.Received(1).HashPassword(originalPassword);
        await _uow.UserRepository.Received(1).CreateAsync(
            Arg.Is<UserEntity>(u => u.Password == hashedPassword),
            Arg.Any<CancellationToken>());
    }

    /// <summary>
    /// Tests that the mapper is called with the correct command.
    /// </summary>
    [Fact(DisplayName = "Given valid command When handling Then maps command to user entity")]
    public async Task Handle_ValidRequest_MapsCommandToUser()
    {
        // Given
        var command = CreateUserHandlerTestData.GenerateValidCommand();
        var user = new UserEntity
        {
            Id = Guid.NewGuid(),
            UserName = command.UserName,
            Password = command.Password,
            Email = command.Email,
            Phone = command.Phone,
            Status = command.Status,
            Role = command.Role
        };

        _mapper.Map<UserEntity>(command).Returns(user);
        _uow.UserRepository.CreateAsync(Arg.Any<UserEntity>(), Arg.Any<CancellationToken>())
            .Returns(user);
        _passwordEncryption.HashPassword(Arg.Any<string>()).Returns("hashedPassword");

        // When
        await _handler.Handle(command, CancellationToken.None);

        // Then
        _mapper.Received(1).Map<UserEntity>(Arg.Is<CreateUserCommand>(c =>
            c.UserName == command.UserName &&
            c.Email == command.Email &&
            c.Phone == command.Phone &&
            c.Status == command.Status &&
            c.Role == command.Role));
    }
}
