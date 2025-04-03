using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Handle.ProductsInSales.Get;

public class GetProductsInSalesValidator : AbstractValidator<GetProductsInSalesCommand>
{
    /// <summary>
    /// Initializes validation rules for GetProductsInSalesCommand
    /// </summary>
    public GetProductsInSalesValidator()
    {
        RuleFor(x => x.SaleId)
            .NotEmpty()
            .WithMessage("ProductsInSales ID is required");
    }
}
