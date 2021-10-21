using System;
using System.Collections.Generic;
using System.Text;

namespace Infrostructure.Exeption
{
   public class InvalidCashAmountExeption:Exception
    {
        public InvalidCashAmountExeption(string messsage = "مقدار خالی وارد شده است"):base(messsage){}
    }
}
