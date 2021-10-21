using Infrostructure.Exeption;

namespace DomainModel.Entity.AmountClasses
{
    /// <summary>
    /// مبلغ
    /// </summary>
    public class Amount
    {
        private const decimal MinValue = 0m;
        /// <summary>
        /// مقدار تعداد
        /// </summary>
        public decimal Value{ get;private set; }
        public Amount(decimal value)
        {
            Validation(value);
            Value = value;
        }
        private void Validation(decimal value)
        {
            if (value < MinValue)
                throw new InvalidAmountExeption();
        }
        public static Amount operator +(Amount first, Amount second)
        {
            return new Amount(first.Value + second.Value);
        }
        public static Amount operator -(Amount first, Amount second)
        {
            return new Amount(first.Value - second.Value);
        }

        public static Amount operator /(Amount first, Amount second)
        {
            return new Amount(first.Value / second.Value);
        }

        public static Amount operator *(Amount first, Amount second)
        {
            return new Amount(first.Value * second.Value);
        }

        public bool Equal(Amount amount)
        {
            if (Value == amount.Value) return true; 
            return false;
        }

        public Amount Multiplication(decimal value)
        {
           return new Amount(Value * value);
        }

        public Amount Division(decimal value)
        {
            return new Amount(Value / value);
        }
    }
}
