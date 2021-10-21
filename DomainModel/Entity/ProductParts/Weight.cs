using Infrostructure.Exeption;

namespace DomainModel.Entity.ProductParts
{
    /// <summary>
    /// وزن
    /// </summary>
    public class Weight
    {
        private const decimal MinValue = 0m;
        public decimal Value { get; private set; }

        public Weight(decimal value)
        {
            ValidateWeightValue(value);
            Value = value;
        }

        private void ValidateWeightValue(decimal value)
        {
            if (value < MinValue) throw new InvalidWeightMeasureValueException(value.ToString());
        }
    }
}
