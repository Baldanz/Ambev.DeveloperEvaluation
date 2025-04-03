using Ambev.DeveloperEvaluation.UoW.Interface;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class SalesValidator
    {
        #region attributes

        private readonly IUoW _uow;

        #endregion

        #region constructors

        public SalesValidator(IUoW uow) => _uow = uow;

        #endregion

        #region methods

        public void GetDiscountsOverProductQuantity(Guid productId, int quantity)
        {
            var products = _uow.ProductRepository.GetAllAsync().Result.ToList();
            var product = products.Where(x => x.Id == productId).Distinct();
            var price = product.FirstOrDefault().Price;
            var count = product.Count();

            if (count > 0)
            {
                if (quantity is > 4 and < 10)
                    Discount = 10;

                else if (quantity is > 10 and < 20)
                    Discount = 20;

                // original price
                Price = price;

                if (Discount.Equals(10) || Discount.Equals(20))
                    Price = price - (price * (Discount / 100));
            }
        }

        #endregion

        #region properties

        public decimal Price { get; set; } = decimal.Zero;
        public decimal Discount { get; set; } = decimal.Zero;

        #endregion
    }
}
