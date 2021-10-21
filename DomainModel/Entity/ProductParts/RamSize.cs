using Infrostructure.Exeption;

namespace DomainModel.Entity.ProductParts
{
    /// <summary>
    /// حجم رم
    /// </summary>
    public class RamSize
    {
        private const decimal MinValue = 0m;
        public decimal Value { get; private set; }

        public RamSize(decimal value)
        {
            ValidateRamSizeValue(value);
            Value = value;
        }

        private void ValidateRamSizeValue(decimal value)
        {
            if (value < MinValue) throw new InvalidRamSizeMeasureValueException(value.ToString());
        }
    }
}
