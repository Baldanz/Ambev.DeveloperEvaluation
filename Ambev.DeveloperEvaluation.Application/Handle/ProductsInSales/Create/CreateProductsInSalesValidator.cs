using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Handle.ProductsInSales.Create;

public class CreateProductsInSalesValidator : AbstractValidator<CreateProductsInSalesCommand>
{
    #region constructors

    public CreateProductsInSalesValidator() 
    {
        RuleFor(p => p.SaleId).NotEmpty().WithMessage("Sale is mandatory");
        RuleFor(p => p.ProductId).NotEmpty().WithMessage("Product is mandatory");
    }

    #endregion
}
