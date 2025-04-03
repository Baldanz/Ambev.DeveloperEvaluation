using Ambev.DeveloperEvaluation.ORM.Repository.Interface;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Handle.Sales.Delete
{
    public class DeleteSalesHandler : IRequestHandler<DeleteSalesCommand, DeleteSalesResponse>
    {
        #region atributes

        private readonly ISalesRepository _repository;

        #endregion

        #region constructors

        public DeleteSalesHandler(ISalesRepository repository) => _repository = repository;

        #endregion

        #region methods

        /// <summary>
        /// handle for delete command
        /// </summary>
        /// <param name="request">required Sales id</param>
        /// <param name="cancellationToken">cancelation token registered after deletion errors</param>
        /// <returns>returns delete operation</returns>
        /// <exception cref="ValidationException">validation getting the system operation exception</exception>
        /// <exception cref="KeyNotFoundException">parameter id getting the system operation exception</exception>
        public async Task<DeleteSalesResponse> Handle(DeleteSalesCommand request, CancellationToken cancellationToken)
        {
            // variable creation block
            var validator = new DeleteSalesValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            // condition for validation before deletion
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            // prepare the Sales record for deletion command
            var sucess = await _repository.DeleteAsync(request.Id, cancellationToken);
            
            // condition for deletion command acomplishment
            if (!sucess)
                throw new KeyNotFoundException($"Sales with ID {request.Id} not found");

            return new DeleteSalesResponse { Success = sucess };
        }

        #endregion
    }
}
