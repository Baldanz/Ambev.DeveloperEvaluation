using Ambev.DeveloperEvaluation.ORM.Repository.Interface;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handle.ProductsInSales.Delete
{
    public class DeleteProductsInSalesHandler : IRequestHandler<DeleteProductsInSalesCommand, DeleteProductsInSalesResponse>
    {
        #region atributes

        private readonly IProductsInSalesRepository _repository;

        #endregion

        #region constructors

        public DeleteProductsInSalesHandler(IProductsInSalesRepository repository) => _repository = repository;

        #endregion

        #region methods

        /// <summary>
        /// handle for delete command
        /// </summary>
        /// <param name="request">required ProductsInSales id</param>
        /// <param name="cancellationToken">cancelation token registered after deletion errors</param>
        /// <returns>returns delete operation</returns>
        /// <exception cref="ValidationException">validation getting the system operation exception</exception>
        /// <exception cref="KeyNotFoundException">parameter id getting the system operation exception</exception>
        public async Task<DeleteProductsInSalesResponse> Handle(DeleteProductsInSalesCommand request, CancellationToken cancellationToken)
        {
            // variable creation block
            var validator = new DeleteProductsInSalesValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            // condition for validation before deletion
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            // prepare the ProductsInSales record for deletion command
            var sucess = await _repository.DeleteAsync(request.SaleId, request.ProductId, cancellationToken);
            
            // condition for deletion command acomplishment
            if (!sucess)
                throw new KeyNotFoundException($"Sale with ID {request.SaleId} and Product with ID {request.ProductId} not found");

            return new DeleteProductsInSalesResponse { Success = sucess };
        }

        #endregion
    }
}
