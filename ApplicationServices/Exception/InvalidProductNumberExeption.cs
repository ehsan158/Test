using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationServices.Exception
{
   public class InvalidProductNumberExeption:System.Exception
    {
        public InvalidProductNumberExeption(string message = "شماره محصول نا معتبر می باشد"):base(message){}
    }
}
