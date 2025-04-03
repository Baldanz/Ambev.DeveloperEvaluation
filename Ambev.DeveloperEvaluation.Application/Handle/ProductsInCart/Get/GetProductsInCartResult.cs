namespace Ambev.DeveloperEvaluation.Application.Handle.ProductsInCart.Get;

public class GetProductsInCartResult
{
    #region properties

    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public Guid CartId { get; set; }

    #endregion
}