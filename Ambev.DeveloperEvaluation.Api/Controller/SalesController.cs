using Ambev.DeveloperEvaluation.Api.Common;
using Ambev.DeveloperEvaluation.Api.Feature.Feature.ProductsInSales.Get;
using Ambev.DeveloperEvaluation.Api.Feature.Product.Get;
using Ambev.DeveloperEvaluation.Api.Feature.ProductsInSales.Get;
using Ambev.DeveloperEvaluation.Api.Feature.Ratings.Feature.Sales.Get;
using Ambev.DeveloperEvaluation.Api.Feature.Sales.Create;
using Ambev.DeveloperEvaluation.Api.Feature.Sales.Get;
using Ambev.DeveloperEvaluation.Application.Handle.Product.Get;
using Ambev.DeveloperEvaluation.Application.Handle.ProductsInSales.Create;
using Ambev.DeveloperEvaluation.Application.Handle.ProductsInSales.Get;
using Ambev.DeveloperEvaluation.Application.Handle.Sales.Create;
using Ambev.DeveloperEvaluation.Application.Handle.Sales.Delete;
using Ambev.DeveloperEvaluation.Application.Handle.Sales.Get;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.Delete;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSales;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.Api.Controller;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class SalesController : BaseController
{
    #region attributes

    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ILogger<SalesController> _logger;
    private readonly SalesValidator _salesValidator;

    #endregion

    #region constructors

    /// <summary>
    /// SalesController constructor
    /// </summary>
    /// <param name="mediator">mediator instance</param>
    /// <param name="mapper">AutoMapper instance</param>
    public SalesController(IMediator mediator, IMapper mapper, ILogger<SalesController> logger, SalesValidator salesValidator)
    {
        _mediator = mediator;
        _mapper = mapper;
        _logger = logger;
        _salesValidator = salesValidator;
    }

    #endregion

    #region methods

    /// <summary>
    /// creates a new Sales in database
    /// </summary>
    /// <param name="request">request data to createe Sales</param>
    /// <param name="cancellationToken">cancelation token after command requst</param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateSalesResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateSales([FromBody] CreateSalesRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Checking the products to purchase sale");

        // checks if cart products and requested are the same
        var cartCommand = new GetListSalesCommand();
        var cartResponse = await _mediator.Send(cartCommand, cancellationToken);

        if (cartResponse.Count(x => x.UserId == request.UserId) == 0)
        {
            _logger.LogInformation($"No carts found for the user {request.UserId}");
            return BadRequest($"No carts found for the user {request.UserId}");
        }

        var cartId = cartResponse.FirstOrDefault(x => x.UserId == request.UserId).Id;
        var listProductsInSales = new List<GetProductsInSalesResult>();

        foreach (var product in request.Products)
        {
            var productSalesCommand = new GetProductsInSalesCommand(cartId, product.ProductId);
            var productSalesResponse = await _mediator.Send(productSalesCommand, cancellationToken);
            
            listProductsInSales.Add(productSalesResponse);
        }

        if (request.Products.Count > listProductsInSales.Count())
            return BadRequest("The quantity of products in the cart is more then the products for sales");
        else
        {
            foreach (var product in request.Products)
            {
                if (listProductsInSales.Count(x => x.ProductId == product.ProductId) == 0)
                    return BadRequest($"The product {product.ProductId} is not in the cart");
            }
        }

        // creating a sale record
        _logger.LogInformation("Creating a record of Sale for the requested User");

        var salesValidator = new CreateSalesRequestValidator();
        var salesValidationResult = await salesValidator.ValidateAsync(request, cancellationToken);

        if (!salesValidationResult.IsValid)
            return BadRequest(salesValidationResult.Errors);

        _logger.LogInformation("Getting a list of registered products");

        var productRequest = new GetListProductRequest();
        var prodcutCommand = _mapper.Map<GetListProductCommand>(productRequest);
        var productResponse = await _mediator.Send(prodcutCommand, cancellationToken);

        foreach (var product in request.Products)
        {
            _logger.LogInformation("Calculating the price with discounts by discount rules");

            _salesValidator.GetDiscountsOverProductQuantity(product.ProductId, product.Quantity);
            var productsRequest = request.Products.FirstOrDefault(x => x.ProductId == product.ProductId);

            productsRequest.Price = _salesValidator.Price;
            productsRequest.Discount = _salesValidator.Discount;

            _logger.LogInformation("Calculating the sales amount");
            request.SaleAmmount += productsRequest.Price;
        }

        var salesRequestCommand = new CreateSalesCommand
        {
            UserId = request.UserId,
            SaleDate = request.SaleDate,
            SaleBranch = request.SaleBranch,
            SaleAmmount = request.SaleAmmount
        };

        _logger.LogInformation("Getting the items of registered products");

        var salesCommand = _mapper.Map<CreateSalesCommand>(salesRequestCommand);
        var salesResponse = await _mediator.Send(salesCommand, cancellationToken);

        foreach(var product in request.Products)
        {
            var productsSalesRequest = new CreateProductsInSalesCommand
            {
                SaleId = salesResponse.Id,
                Discount = product.Discount,
                ProductId = product.ProductId,
                Price = product.Price,
                Quantity = product.Quantity,
            };

            var productsSalesCommand = _mapper.Map<CreateProductsInSalesCommand>(productsSalesRequest);
            var productsSalesResponse = await _mediator.Send(productsSalesCommand, cancellationToken);

            if (!productsSalesResponse.Equals(null))
            {
                _logger.LogInformation($"Product ID {product.ProductId} registered successfully");
                salesResponse.Products.Add(productsSalesResponse);
            }
        }

        if (!salesResponse.Equals(null))
        {
            var deleteSalesCommand = _mapper.Map<DeleteSalesCommand>(cartId);
            var deleteSalesResponse = await _mediator.Send(deleteSalesCommand, cancellationToken);

            // logs for cart deletion
            if (deleteSalesResponse.Success)
                _logger.LogInformation("Sales deleted successfully");
            else
                _logger.LogInformation($"Sales id {cartId} not found toe be deleted");
        }

        return Created(string.Empty, new ApiResponseWithData<CreateSalesResponse>
        {
            Success = true,
            Message = "Sales created successfully",
            Data = _mapper.Map<CreateSalesResponse>(salesResponse)
        });
    }

    /// <summary>
    /// Retrieves a product by their ID
    /// </summary>
    /// <param name="id">The unique identifier of the product</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The product details if found</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetSalesResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetSales([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var salesRequest = new GetSalesRequest { Id = id };
        var salesValidator = new GetSalesRequestValidator();
        var validationSalesResult = await salesValidator.ValidateAsync(salesRequest, cancellationToken);

        _logger.LogInformation("Sales validation");

        if (!validationSalesResult.IsValid)
            return BadRequest(validationSalesResult.Errors);

        _logger.LogInformation("Getting the sales records");

        var commandGetSales = _mapper.Map<GetSalesCommand>(salesRequest.Id);
        var responseGetSales = await _mediator.Send(commandGetSales, cancellationToken);

        if (!responseGetSales.Equals(null))
            _logger.LogInformation("Sales record retrived successfully");
        else
            return BadRequest($"Sales record with ID { id } not found");

        var requestGetProductsSales = new GetListProductsInSalesRequest();
        var commandGetProductsSales = _mapper.Map<GetListProductsInSalesCommand>(requestGetProductsSales);
        var responseGetProductsSales = await _mediator.Send(commandGetProductsSales, cancellationToken);
        var listProductsSales = responseGetProductsSales.Where(x => x.SaleId == id);

        if (listProductsSales.Count() == 0)
        {
            _logger.LogInformation($"Products for Sale ID { id } not found");
            return BadRequest($"Sales record with ID {id} not found");
        }

        foreach (var product in listProductsSales)
        {
            var requestProductsSales = new GetProductsInSalesRequest()
            { SaleId = product.SaleId, ProductId = product.ProductId };
            var validatorProductsSalesResult = await new GetProductsInSalesRequestValidator().ValidateAsync(requestProductsSales, cancellationToken);

            if (!validatorProductsSalesResult.IsValid)
                return BadRequest(validatorProductsSalesResult.Errors);

            responseGetSales.Products.Add(product);
            _logger.LogInformation($"Product {product.ProductId} for Sale ID {id} retrieved successfully");
        }

        _logger.LogInformation($"Sale ID { id } retrieved successfully");

        return Ok(new ApiResponseWithData<GetSalesResponse>
        {
            Success = true,
            Message = "Sales retrieved successfully",
            Data = _mapper.Map<GetSalesResponse>(responseGetSales)
        });
    }

    [HttpGet("{pageNumber},{pageSize}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetSalesResult>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllSaless([FromRoute] int pageNumber = 1, int pageSize = 10, CancellationToken cancellationToken = default)
    {
        var requestSales = new GetListSalesRequest();
        var commandSales = _mapper.Map<GetListSalesCommand>(requestSales);
        var responseSales = await _mediator.Send(commandSales, cancellationToken);
        var responseListSales = responseSales.ToList();

        foreach (var item in responseListSales)
        {
            var requestProductSales = new GetListProductsInSalesRequest();
            var commandProductSales = _mapper.Map<GetListProductsInSalesCommand>(requestProductSales);
            var responseProductSales = await _mediator.Send(commandProductSales, cancellationToken);
            var responseListProductSales = responseProductSales.ToList();

            responseListSales
                .Find(x => x.Id == item.Id)
                .Products
                .AddRange(responseListProductSales.Where(x => x.SaleId == item.Id));
        }

        var pagedList = new PaginatedList<GetSalesResult>(responseListSales, responseListSales.Count(), pageNumber, pageSize);

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
    public async Task<IActionResult> DeleteSales([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new DeleteSalesRequest { Id = id };
        var validator = new DeleteSalesRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        _logger.LogInformation("Sales validation");

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<DeleteSalesCommand>(request.Id);
        await _mediator.Send(command, cancellationToken);

        _logger.LogInformation("Sales deletion");

        return Ok(new ApiResponse
        {
            Success = true,
            Message = "Sales deleted successfully"
        });
    }

    #endregion
}