using Ambev.DeveloperEvaluation.Entity.Validation;
using MediatR;
using System.Text.Json.Serialization;

namespace Ambev.DeveloperEvaluation.Application.Handle.ProductsInCart.Create;

public class CreateProductsInCartCommand : IRequest<CreateProductsInCartResult>
{
    #region properties

    [JsonIgnore]
    public Guid CartId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }

    #endregion

    #region methods

    public ValidationResult Validate()
    {
        var validator = new CreateProductsInCartValidator();
        var result = validator.Validate(this);
        return new ValidationResult
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationError)o)
        };
    }

    #endregion
}
