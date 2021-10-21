using Infrostructure.Exeption;

namespace DomainModel.Entity.ProductParts
{
    /// <summary>
    /// وات مصرفی
    /// </summary>
    public class Wattage
    {
        private const decimal MinValue = 0m;
        public decimal Value { get; private set; }

        public Wattage(decimal value)
        {
            ValidateWattageValue(value);
            Value = value;
        }

        private void ValidateWattageValue(decimal value)
        {
            if (value < MinValue) throw new InvalidWattageMeasureValueException(value.ToString());
        }
    }
}
