using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Handle.ProductsInSales.Delete;

/// <summary>
/// Validator for DeleteProductsInSalesCommand
/// </summary>
public class DeleteProductsInSalesValidator : AbstractValidator<DeleteProductsInSalesCommand>
{
    /// <summary>
    /// Initializes validation rules for DeleteProductsInSalesCommand
    /// </summary>
    public DeleteProductsInSalesValidator()
    {
        RuleFor(x => x.SaleId).NotEmpty().WithMessage("Sale ID is required");
        RuleFor(x => x.ProductId).NotEmpty().WithMessage("Sale ID is required");
    }
}
