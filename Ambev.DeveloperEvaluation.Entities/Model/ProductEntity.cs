using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Interface;

namespace Ambev.DeveloperEvaluation.Domain.Model
{
    public class ProductEntity : BaseEntity, IProductEntity
    {
        #region properties
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Image {  get; set; } = string.Empty;
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        #endregion

        #region constructors

        public ProductEntity()
        {
            CreatedAt = DateTime.UtcNow;
        }
        #endregion

        #region interface implementation

        string IProductEntity.Id => Id.ToString();

        #endregion
    }
}
