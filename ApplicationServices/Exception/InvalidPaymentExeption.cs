using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationServices.Exception
{
   public class InvalidPaymentExeption:System.Exception
    {
        public InvalidPaymentExeption(string message = "پرداخت خالی است"):base(message){}
    }
}
