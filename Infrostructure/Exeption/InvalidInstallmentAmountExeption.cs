using System;
using System.Collections.Generic;
using System.Text;

namespace Infrostructure.Exeption
{
   public class InvalidInstallmentAmountExeption:Exception
    {
        public InvalidInstallmentAmountExeption(string message = "مقدار خالی وارد شده است"):base(message){}
    }
}
