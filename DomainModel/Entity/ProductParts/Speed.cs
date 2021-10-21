using Infrostructure.Exeption;

namespace DomainModel.Entity.ProductParts
{
    /// <summary>
    /// سرعت
    /// </summary>
    public class Speed
    {
        private const decimal MinValue = 0m;
        public decimal Value { get; private set; }

        public Speed(decimal value)
        {
            ValidateSpeedValue(value);
            Value = value;
        }

        private void ValidateSpeedValue(decimal value)
        {
            if (value < MinValue) throw new InvalidSpeedMeasureValueException(value.ToString());
        }
    }
}
