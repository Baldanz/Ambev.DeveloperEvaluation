namespace Ambev.DeveloperEvaluation.Domain.Common
{
    public class BaseEntity : IComparable<BaseEntity>
    {
        #region methods

        public int CompareTo(BaseEntity? other)
        {
            if (other == null)
            {
                return 1;
            }

            return other!.Id.CompareTo(Id);
        }

        #endregion

        #region properties

        public Guid Id { get; set; }

        #endregion
    }
}
