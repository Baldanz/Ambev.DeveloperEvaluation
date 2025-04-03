using FluentValidation;

namespace Ambev.DeveloperEvaluation.Api.Feature.ProductsInSales.Create;

public class CreateProductsInSalesRequestValidator : AbstractValidator<CreateProductsInSalesRequest>
{
    public CreateProductsInSalesRequestValidator()
    {
        RuleFor(p => p.SaleId).NotEmpty().WithMessage("Sale is mandatory");
        RuleFor(p => p.ProductId).NotEmpty().WithMessage("Product is mandatory");
        RuleFor(p => p.Quantity).NotEmpty().WithMessage("Quantity is mandatory");
    }
}