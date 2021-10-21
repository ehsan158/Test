using Infrostructure.Exeption;

namespace DomainModel.Entity.ProductParts
{
    /// <summary>
    /// واحد جریان پردازش
    /// </summary>
    public class StreamProcessorUnit
    {
        private const decimal MinValue = 0m;
        public decimal Value { get; private set; }

        public StreamProcessorUnit(decimal value)
        {
            ValidateStreamProcessorUnitValue(value);
            Value = value;
        }

        private void ValidateStreamProcessorUnitValue(decimal value)
        {
            if (value < MinValue) throw new InvalidStreamProcessorUnitMeasureValueException(value.ToString());
        }
    }
}
