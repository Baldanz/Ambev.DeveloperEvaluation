using Ambev.DeveloperEvaluation.Api.Common;
using Ambev.DeveloperEvaluation.Api.Feature.Product.Create;
using Ambev.DeveloperEvaluation.Api.Feature.Product.Get;
using Ambev.DeveloperEvaluation.Api.Feature.Rating.Create;
using Ambev.DeveloperEvaluation.Api.Feature.Ratings.Feature.Product.Get;
using Ambev.DeveloperEvaluation.Api.Feature.Ratings.Feature.Ratings.Get;
using Ambev.DeveloperEvaluation.Application.Handle.Product.Create;
using Ambev.DeveloperEvaluation.Application.Handle.Product.Delete;
using Ambev.DeveloperEvaluation.Application.Handle.Product.Get;
using Ambev.DeveloperEvaluation.Application.Handle.Rating.Create;
using Ambev.DeveloperEvaluation.Application.Handle.Rating.Get;
using Ambev.DeveloperEvaluation.WebApi.Features.Product.Delete;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.Api.Controller;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProductController : BaseController
{
    #region attributes

    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ILogger<ProductController> _logger;

    #endregion

    #region constructors

    /// <summary>
    /// ProductsController constructor
    /// </summary>
    /// <param name="mediator">mediator instance</param>
    /// <param name="mapper">AutoMapper instance</param>
    public ProductController(IMediator mediator, IMapper mapper, ILogger<ProductController> logger)
    {
        _mediator = mediator;
        _mapper = mapper;
        _logger = logger;
    }

    #endregion

    #region methods

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateProductResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating a record of Products");

        var validator = new CreateProductRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateProductCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        var commandRating = _mapper.Map<CreateRatingCommand>(request.Rate);
        commandRating.ProductId = response.Id;
        var responseRating = await _mediator.Send(commandRating, cancellationToken);

        // response
        var responseProdut = _mapper.Map<CreateProductResponse>(response);
        responseProdut.Rating = _mapper.Map<CreateRatingResponse>(responseRating);

        return Created(string.Empty, new ApiResponseWithData<CreateProductResponse>
        {
            Success = true,
            Message = "Product created successfully",
            Data = _mapper.Map<CreateProductResponse>(responseProdut)
        });
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetProductResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProduct([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new GetProductRequest { Id = id };

        var validator = new GetProductRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetProductCommand>(request.Id);
        var response = await _mediator.Send(command, cancellationToken);

        var requestRating = new GetRatingRequest { Id = null, ProductId = response.Id };
        var commandRating = _mapper.Map<GetRatingCommand>(requestRating);

        var responseRating = await _mediator.Send(commandRating, cancellationToken);
        response.Rating = responseRating;

        return Ok(new ApiResponseWithData<GetProductResponse>
        {
            Success = true,
            Message = "Product retrieved successfully",
            Data = _mapper.Map<GetProductResponse>(response)
        });
    }

    [HttpGet("{pageNumber},{pageSize}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetProductResult>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllProducts([FromRoute] int pageNumber = 1, int pageSize = 10, CancellationToken cancellationToken = default)
    {
        var request = new GetListProductRequest();

        var command = _mapper.Map<GetListProductCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);
        var responseList = response.ToList();

        foreach (var item in responseList)
        {
            var requestRating = new GetRatingRequest { ProductId = item.Id };
            var commandRating = _mapper.Map<GetRatingCommand>(requestRating);
            var responseRating = await _mediator.Send(commandRating, cancellationToken);

            item.Rating = new GetRatingResult()
            { 
                Rate = responseRating.Rate,
                Count = responseRating.Count 
            };            

            responseList.Where(x => x.Id == item.Id).ToList().Add(item);
        }

        var pagedList = new PaginatedList<GetProductResult>(responseList, responseList.Count(), pageNumber, pageSize);

        return OkPaginated(pagedList);
    }

    [HttpGet("category/{pageNumber},{pageSize}")]
    [ProducesResponseType(typeof(ApiResponseWithData<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllProductsCategory([FromRoute] int pageNumber = 1, int pageSize = 10, CancellationToken cancellationToken = default)
    {
        var request = new GetListProductRequest();

        var command = _mapper.Map<GetListProductCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);
        var categoryList = new List<string>();

        foreach (var item in response.GroupBy(x => x.Category).Select(x => x.FirstOrDefault()).ToList())
            categoryList.Add(item.Category);
        
        var pagedList = new PaginatedList<string>(categoryList, categoryList.Count(), pageNumber, pageSize);

        return OkPaginated(pagedList);
    }

    [HttpGet("category/{category},{pageNumber},{pageSize}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetProductResult>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllProducts([FromRoute]string category, int pageNumber = 1, int pageSize = 10, CancellationToken cancellationToken = default)
    {
        var request = new GetListProductRequest();

        var command = _mapper.Map<GetListProductCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);
        var responseList = response.Where(x => x.Category == category).ToList();

        foreach (var item in responseList)
        {
            var requestRating = new GetRatingRequest { ProductId = item.Id };
            var commandRating = _mapper.Map<GetRatingCommand>(requestRating);
            var responseRating = await _mediator.Send(commandRating, cancellationToken);

            item.Rating = new GetRatingResult()
            {
                Rate = responseRating.Rate,
                Count = responseRating.Count
            };

            responseList.Where(x => x.Id == item.Id).ToList().Add(item);
        }

        var pagedList = new PaginatedList<GetProductResult>(responseList, responseList.Count(), pageNumber, pageSize);

        return OkPaginated(pagedList);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteProduct([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new DeleteProductRequest { Id = id };
        var validator = new DeleteProductRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<DeleteProductCommand>(request.Id);
        await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponse
        {
            Success = true,
            Message = "Product deleted successfully"
        });
    }

    #endregion
}