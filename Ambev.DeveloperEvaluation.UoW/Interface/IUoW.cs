using Ambev.DeveloperEvaluation.ORM.Repository.Interface;

namespace Ambev.DeveloperEvaluation.UoW.Interface;

public interface IUoW
{
    #region properties

    // repositories
    IUserRepository UserRepository { get; }
    IProductRepository ProductRepository { get; }
    IRatingRepository RatingRepository { get; }
    ICartRepository CartRepository { get; }
    IProductsInCartRepository ProductsInCartRepository { get; }
    ISalesRepository SalesRepository { get; }
    IProductsInSalesRepository ProductsInSalesRepository { get; }

    #endregion
}
