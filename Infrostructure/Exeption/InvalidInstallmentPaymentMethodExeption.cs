using System;

namespace Infrostructure.Exeption
{
    public class InvalidInstallmentPaymentMethodExeption:Exception
    {
        public InvalidInstallmentPaymentMethodExeption(string message = "تعداد اقساط انتخاب نشده است") : base(message) { }
    }
}
