namespace Ambev.DeveloperEvaluation.Application.Handle.ProductsInCart.Create;

public class CreateProductsInCartResult
{
    #region properties
    public Guid CartId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    #endregion
}
