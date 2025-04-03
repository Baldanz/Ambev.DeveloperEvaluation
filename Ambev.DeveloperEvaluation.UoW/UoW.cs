using Ambev.DeveloperEvaluation.ORM.Repository.Interface;
using Ambev.DeveloperEvaluation.UoW.Interface;

namespace Ambev.DeveloperEvaluation.UoW;

public sealed class UoW : IUoW
{
    #region attributes

    private readonly IUserRepository _userRepository;
    private readonly IProductRepository _productRepository;
    private readonly IRatingRepository _ratingRepository;
    private readonly ICartRepository _cartRepository;
    private readonly IProductsInCartRepository _productInCartRepository;
    private readonly ISalesRepository _salesRepository;
    private readonly IProductsInSalesRepository _productsInSalesRepository;

    #endregion

    #region constructors

    /// <summary>
    /// UoW constructor
    /// </summary>
    /// <param name="userCommand">user command as a uow</param>
    public UoW (IUserRepository userRepository,
        IProductRepository productRepository,
        IRatingRepository ratingRepository,
        ICartRepository cartRepository,
        IProductsInCartRepository productInCartRepository,
        ISalesRepository salesRepository,
        IProductsInSalesRepository productsInSalesRepository)
    {
        _userRepository = userRepository;
        _productRepository = productRepository;
        _ratingRepository = ratingRepository;
        _cartRepository = cartRepository;
        _productInCartRepository = productInCartRepository;
        _salesRepository = salesRepository;
        _productsInSalesRepository = productsInSalesRepository;
    }

    #endregion

    #region properties

    // repositories
    public IUserRepository UserRepository => _userRepository;
    public IProductRepository ProductRepository => _productRepository;
    public IRatingRepository RatingRepository => _ratingRepository;
    public ICartRepository CartRepository => _cartRepository;
    public IProductsInCartRepository ProductsInCartRepository => _productInCartRepository;
    public ISalesRepository SalesRepository => _salesRepository;
    public IProductsInSalesRepository ProductsInSalesRepository => _productsInSalesRepository;

    #endregion
}
