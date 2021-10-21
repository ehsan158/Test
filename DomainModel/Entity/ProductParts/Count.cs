using Infrostructure.Exeption;

namespace DomainModel.Entity.ProductParts
{
    /// <summary>
    /// تعداد
    /// </summary>
    public class Count
    {
        private const int MinValue = 0;
        public Count(int value)
        {
            ValidateCountValue(value);
            Value = value;
        }
        /// <summary>
        /// مقدار تعداد
        /// </summary>
        public decimal Value { get; private set; }

        private void ValidateCountValue(int value)
        {
            if (value < MinValue)
            {
                throw new InvalidCountValueException(value.ToString());
            }
        }
    }
}
