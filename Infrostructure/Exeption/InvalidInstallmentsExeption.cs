using System;

namespace Infrostructure.Exeption
{
    public class InvalidInstallmentPaymentExeption : Exception
    {
        public InvalidInstallmentPaymentExeption(string message = "پرداهت اقساطی به درستی پر نشده است(لیست اقساط خالی است یا مبلغ نهایی ثبت نشده است)") : base(message) { }
    }
}
