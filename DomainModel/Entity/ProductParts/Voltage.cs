using Infrostructure.Exeption;

namespace DomainModel.Entity.ProductParts
{
    /// <summary>
    /// ولتاژ
    /// </summary>
    public class Voltage
    {
        private const decimal MinValue = 0m;
        public decimal Value { get; private set; }

        public Voltage(decimal value)
        {
            ValidateVoltageValue(value);
            Value = value;
        }

        private void ValidateVoltageValue(decimal value)
        {
            if (value < MinValue) throw new InvalidVoltageMeasureValueException(value.ToString());
        }
    }
}
