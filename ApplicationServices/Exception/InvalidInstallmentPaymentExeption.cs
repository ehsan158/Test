using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationServices.Exception
{
   public class InvalidInstallmentPaymentExeption:System.Exception
    {
        public InvalidInstallmentPaymentExeption(string message = "روش پرداخت خالی فرستاده شده است."):base(message){}
    }
}
