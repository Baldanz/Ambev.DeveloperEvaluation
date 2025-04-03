using Ambev.DeveloperEvaluation.Entity.Validation;
using MediatR;
using System.Text.Json.Serialization;

namespace Ambev.DeveloperEvaluation.Application.Handle.ProductsInSales.Create;

public class CreateProductsInSalesCommand : IRequest<CreateProductsInSalesResult>
{
    #region properties

    [JsonIgnore]
    public Guid SaleId { get; set; }
    
    public Guid ProductId { get; set; }
    
    [JsonIgnore]
    public decimal Price { get; set; }
    
    [JsonIgnore]
    public decimal Discount { get; set; }
    
    public int Quantity { get; set; }

    [JsonIgnore]
    public decimal TotalAmmount => Price * Quantity;

    #endregion

    #region methods

    public ValidationResult Validate()
    {
        var validator = new CreateProductsInSalesValidator();
        var result = validator.Validate(this);
        return new ValidationResult
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationError)o)
        };
    }

    #endregion
}