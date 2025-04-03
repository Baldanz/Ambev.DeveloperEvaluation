using Ambev.DeveloperEvaluation.Entity.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handle.Sales.Create;

public class CreateSalesCommand : IRequest<CreateSalesResult>
{
    #region properties

    public Guid UserId { get; set; }
    public DateTime SaleDate { get; set; }
    public decimal SaleAmmount { get; set; }
    public string SaleBranch { get; set; } = string.Empty;

    #endregion

    #region methods

    public ValidationResult Validate()
    {
        var validator = new CreateSalesValidator();
        var result = validator.Validate(this);
        return new ValidationResult
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationError)o)
        };
    }

    #endregion
}