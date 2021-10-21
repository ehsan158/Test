using System;

namespace Infrostructure.Exeption
{
    public class InvalidPaymentException : Exception
    {
        public InvalidPaymentException(string message = "سفارش معتبر نیست") : base(message) { }
    }
}
