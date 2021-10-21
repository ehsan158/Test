using Infrostructure.Exeption;

namespace DomainModel.Entity.ProductParts
{
    /// <summary>
    /// فرکانس
    /// </summary>
    public class Frequency
    {
        private const decimal MinValue = 0m;
        public decimal Value { get; private set; }

        public Frequency(decimal value)
        {
            ValidateFrequencyValue(value);
            Value = value;
        }

        private void ValidateFrequencyValue(decimal value)
        {
            if (value < MinValue) throw new InvalidFrequencyMeasureValueException(value.ToString());
        }
    }
}
