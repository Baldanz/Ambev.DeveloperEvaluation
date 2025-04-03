using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.ProductsInSales.Delete;

/// <summary>
/// Validator for DeleteProductsInSalesRequest
/// </summary>
public class DeleteProductsInSalesRequestValidator : AbstractValidator<DeleteProductsInSalesRequest>
{
    /// <summary>
    /// Initializes validation rules for DeleteProductsInSalesRequest
    /// </summary>
    public DeleteProductsInSalesRequestValidator()
    {
        RuleFor(x => x.SaleId).NotEmpty().WithMessage("Sale is required");
        RuleFor(x => x.ProductId).NotEmpty().WithMessage("Product is required");
    }
}
