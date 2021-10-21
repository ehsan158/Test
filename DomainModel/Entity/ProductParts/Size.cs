using Infrostructure.Exeption;

namespace DomainModel.Entity.ProductParts
{
    /// <summary>
    /// ابعاد
    /// </summary>
    public class Size
    {
        private const decimal MinValue = 0m;
        public decimal Value { get; private set; }

        public Size(decimal value)
        {
            ValidateSizeValue(value);
            Value = value;
        }

        private void ValidateSizeValue(decimal value)
        {
            if (value < MinValue) throw new InvalidSizeMeasureValueException(value.ToString());
        }
    }
}
