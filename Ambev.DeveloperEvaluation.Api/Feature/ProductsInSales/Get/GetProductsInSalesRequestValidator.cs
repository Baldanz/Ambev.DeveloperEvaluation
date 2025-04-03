using FluentValidation;

namespace Ambev.DeveloperEvaluation.Api.Feature.Feature.ProductsInSales.Get;
/// <summary>
/// Validator for GetProductsInSalesRequest
/// </summary>
public class GetProductsInSalesRequestValidator : AbstractValidator<GetProductsInSalesRequest>
{
    /// <summary>
    /// Initializes validation rules for GetProductsInSalesRequest
    /// </summary>
    public GetProductsInSalesRequestValidator()
    {
        RuleFor(x => x.SaleId).NotEmpty().WithMessage("Sale is required");
        RuleFor(x => x.ProductId).NotEmpty().WithMessage("Product is required");
    }
}
