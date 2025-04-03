using Ambev.DeveloperEvaluation.Api.Common;
using Ambev.DeveloperEvaluation.Api.Feature.User.Get;
using Ambev.DeveloperEvaluation.Api.Features.User.Create;
using Ambev.DeveloperEvaluation.Api.Features.User.Get;
using Ambev.DeveloperEvaluation.Api.Features.User.Update;
using Ambev.DeveloperEvaluation.Application.Handle.User.Create;
using Ambev.DeveloperEvaluation.Application.Handle.User.Delete;
using Ambev.DeveloperEvaluation.Application.Handle.User.Get;
using Ambev.DeveloperEvaluation.Application.Handle.User.Update;
using Ambev.DeveloperEvaluation.WebApi.Features.User.Delete;
using Ambev.DeveloperEvaluation.WebApi.Features.User.GetUser;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.Api.Controller;

[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
public class UserController : BaseController
{
    #region attributes

    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ILogger<UserController> _logger;

    #endregion

    #region constructors

    /// <summary>
    /// UsersController constructor
    /// </summary>
    /// <param name="mediator">mediator instance</param>
    /// <param name="mapper">AutoMapper instance</param>
    public UserController(IMediator mediator, IMapper mapper, ILogger<UserController> logger)
    {
        _mediator = mediator;
        _mapper = mapper;
        _logger = logger;
    }

    #endregion

    #region methods

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateUserResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating a record of Users");

        var validator = new CreateUserRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateUserCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CreateUserResponse>
        {
            Success = true,
            Message = "User created successfully",
            Data = _mapper.Map<CreateUserResponse>(response)
        });
    }

    [HttpPut]
    [ProducesResponseType(typeof(ApiResponseWithData<UpdateUserResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Updating a record of Users");

        var validator = new UpdateUserRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<UpdateUserCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<UpdateUserResponse>
        {
            Success = true,
            Message = "User updated successfully",
            Data = _mapper.Map<UpdateUserResponse>(response)
        });
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetUserResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetUser([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new GetUserRequest { Id = id };
        var validator = new GetUserRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetUserCommand>(request.Id);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<GetUserResponse>
        {
            Success = true,
            Message = "User retrieved successfully",
            Data = _mapper.Map<GetUserResponse>(response)
        });
    }

    [HttpGet("{pageNumber},{pageSize}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetUserResult>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllUsers([FromRoute] int pageNumber = 1, int pageSize = 10, CancellationToken cancellationToken = default)
    {
        var request = new GetListUserRequest();

        var command = _mapper.Map<GetListUserCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);
        var responseList = response.ToList();
        var pagedList = new PaginatedList<GetUserResult>(responseList, responseList.Count(), pageNumber, pageSize);

        return OkPaginated(pagedList);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteUser([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new DeleteUserRequest { Id = id };
        var validator = new DeleteUserRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<DeleteUserCommand>(request.Id);
        await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponse
        {
            Success = true,
            Message = "User deleted successfully"
        });
    }

    #endregion
}