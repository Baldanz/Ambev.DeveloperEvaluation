namespace Ambev.DeveloperEvaluation.Domain.Model;

public class ProductsInCartEntity
{
	#region properties

	public Guid CartId { get; set; }
	public Guid ProductId { get; set; }
	public int Quantity { get; set; }
	public required CartEntity Cart { get; set; }
	public required ProductEntity Products { get; set; }

	#endregion
}
