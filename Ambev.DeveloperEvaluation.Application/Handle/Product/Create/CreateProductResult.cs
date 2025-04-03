namespace Ambev.DeveloperEvaluation.Application.Handle.Product.Create
{
    public class CreateProductResult
    {
        #region properties

        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public DateTime CreatedAt { get; private set; }

        #endregion
    }
}
