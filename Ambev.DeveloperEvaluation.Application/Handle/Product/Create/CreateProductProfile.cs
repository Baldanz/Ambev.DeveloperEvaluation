using Ambev.DeveloperEvaluation.Domain.Model;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Handle.Product.Create
{
    public class CreateProductProfile : Profile
    {
        #region constructors

        /// <summary>
        /// CreateProductProfile constructor
        /// </summary>
        public CreateProductProfile() 
        {
            CreateMap<CreateProductCommand, ProductEntity>();
            CreateMap<ProductEntity, CreateProductResult>();
        }

        #endregion
    }
}
