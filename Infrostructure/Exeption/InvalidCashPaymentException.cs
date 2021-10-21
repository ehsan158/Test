using System;

namespace Infrostructure.Exeption
{
    public class InvalidCashPaymentException : Exception
    {
        public InvalidCashPaymentException(string message = "مقدار نقدی برای پرداخت وجود ندارد.") : base(message) { }
    }
}
