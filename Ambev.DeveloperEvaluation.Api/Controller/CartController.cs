using Ambev.DeveloperEvaluation.Api.Common;
using Ambev.DeveloperEvaluation.Api.Feature.Cart.Create;
using Ambev.DeveloperEvaluation.Api.Feature.Cart.Get;
using Ambev.DeveloperEvaluation.Api.Feature.Feature.ProductsInCart.Get;
using Ambev.DeveloperEvaluation.Api.Feature.ProductsInCart.Get;
using Ambev.DeveloperEvaluation.Api.Feature.Ratings.Feature.Cart.Get;
using Ambev.DeveloperEvaluation.Application.Handle.Cart.Create;
using Ambev.DeveloperEvaluation.Application.Handle.Cart.Delete;
using Ambev.DeveloperEvaluation.Application.Handle.Cart.Get;
using Ambev.DeveloperEvaluation.Application.Handle.ProductsInCart.Create;
using Ambev.DeveloperEvaluation.Application.Handle.ProductsInCart.Get;
using Ambev.DeveloperEvaluation.WebApi.Features.Cart.Delete;
using Ambev.DeveloperEvaluation.WebApi.Features.Cart.DeleteCart;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.Api.Controller;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CartController : BaseController
{
    #region attributes

    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ILogger<CartController> _logger;

    #endregion

    #region constructors

    /// <summary>
    /// CartsController constructor
    /// </summary>
    /// <param name="mediator">mediator instance</param>
    /// <param name="mapper">AutoMapper instance</param>
    public CartController(IMediator mediator, IMapper mapper, ILogger<CartController> logger)
    {
        _mediator = mediator;
        _mapper = mapper;
        _logger = logger;
    }

    #endregion

    #region methods

    /// <summary>
    /// creates a new Cart in database
    /// </summary>
    /// <param name="request">request data to createe Cart</param>
    /// <param name="cancellationToken">cancelation token after command requst</param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateCartResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateCart([FromBody] CreateCartRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating a record of Carts");

        var validator = new CreateCartRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var requestCommand = new CreateCartCommand { UserId = request.UserId  };
        var command = _mapper.Map<CreateCartCommand>(requestCommand);
        var response = await _mediator.Send(command, cancellationToken);
        var listResponseProducts = new List<CreateProductsInCartResult>();

        _logger.LogInformation("Creating a list of Products' records");

        if (response != null)
        {
            foreach (var product in request.Products)
            {
                product.CartId = response.Id;
                var commandProduct = _mapper.Map<CreateProductsInCartCommand>(product);
                var responseProduct = await _mediator.Send(commandProduct, cancellationToken);
                listResponseProducts.Add(responseProduct);
            }
        }

        response.Products.AddRange(listResponseProducts);

        _logger.LogInformation("Cart created successfully");

        return Created(string.Empty, new ApiResponseWithData<CreateCartResponse>
        {
            Success = true,
            Message = "Cart created successfully",
            Data = _mapper.Map<CreateCartResponse>(response)
        });
    }

    /// <summary>
    /// Retrieves a product by their ID
    /// </summary>
    /// <param name="id">The unique identifier of the product</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The product details if found</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetCartResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCart([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Cart retriveing validation");

        var requestCart = new GetCartRequest { Id = id };
        var validatorCart = new GetCartRequestValidator();
        var validationCartResult = await validatorCart.ValidateAsync(requestCart, cancellationToken);

        if (!validationCartResult.IsValid)
            return BadRequest(validationCartResult.Errors);

        var commandGetCart = _mapper.Map<GetCartCommand>(requestCart.Id);
        var responseGetCart = await _mediator.Send(commandGetCart, cancellationToken);

        var requestGetProductCart = new GetListProductsInCartRequest();
        var commandGetProductCart = _mapper.Map<GetListProductsInCartCommand>(requestGetProductCart);
        var responseGetProductCart = await _mediator.Send(commandGetProductCart, cancellationToken);

        var listProductsCart = responseGetProductCart.Where(x => x.CartId == id);

        foreach (var product in listProductsCart) { 

            var requestProductCart = new GetProductsInCartRequest() 
                { CartId = product.CartId, ProductId = product.ProductId };
            var validatorProductCartResult = await new GetProductsInCartRequestValidator().ValidateAsync(requestProductCart, cancellationToken);

            if (!validatorProductCartResult.IsValid)
                return BadRequest(validatorProductCartResult.Errors);

            responseGetCart.Products.Add(product);

            _logger.LogInformation("Products retrived successfully");
        }

        _logger.LogInformation("Carts retrived successfully");

        return Ok(new ApiResponseWithData<GetCartResponse>
        {
            Success = true,
            Message = "Cart retrieved successfully",
            Data = _mapper.Map<GetCartResponse>(responseGetCart)
        });
    }

    [HttpGet("{pageNumber},{pageSize}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetCartResult>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllCarts([FromRoute] int pageNumber = 1, int pageSize = 10, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation("Cart retriveing validation");

        var requestCart = new GetListCartRequest();
        var commandCart = _mapper.Map<GetListCartCommand>(requestCart);
        var responseCart = await _mediator.Send(commandCart, cancellationToken);
        var responseListCart = responseCart.ToList();
        
        foreach (var item in responseListCart)
        {
            var requestProductCart = new GetListProductsInCartRequest();
            var commandProductCart = _mapper.Map<GetListProductsInCartCommand>(requestProductCart);
            var responseProductCart = await _mediator.Send(commandProductCart, cancellationToken);
            var responseListProductCart = responseProductCart.ToList();            
            
            responseListCart
                .Find(x => x.Id == item.Id)
                .Products
                .AddRange(responseListProductCart.Where(x => x.CartId == item.Id));
        }

        var pagedList = new PaginatedList<GetCartResult>(responseListCart, responseListCart.Count(), pageNumber, pageSize);

        _logger.LogInformation("List of carts retrived successfully");

        return OkPaginated(pagedList);
    }

    /// <summary>
    /// Deletes a product by their ID
    /// </summary>
    /// <param name="id">The unique identifier of the product to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Success response if the product was deleted</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteCart([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Carts retrieving validation");

        var request = new DeleteCartRequest { Id = id };
        var validator = new DeleteCartRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<DeleteCartCommand>(request.Id);
        await _mediator.Send(command, cancellationToken);

        _logger.LogInformation("Cart deleted successfully");

        return Ok(new ApiResponse
        {
            Success = true,
            Message = "Cart deleted successfully"
        });
    }

    #endregion
}
