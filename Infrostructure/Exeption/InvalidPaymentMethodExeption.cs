using System;

namespace Infrostructure.Exeption
{
    public class InvalidPaymentMethodExeption:Exception
    {
        public InvalidPaymentMethodExeption(string message = "نوع روش پرداخت خالی است") : base(message) { }
    }
}
