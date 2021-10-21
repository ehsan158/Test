using System;
using System.Collections.Generic;
using System.Text;

namespace Infrostructure.Exeption
{
   public class InvalidProductsExeption:Exception
    {
        public InvalidProductsExeption(string message = "محصولات وارد شده معتبر نمی باشد"):base(message){}
    }
}
