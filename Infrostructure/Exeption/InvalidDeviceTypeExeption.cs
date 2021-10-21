using System;
using System.Collections.Generic;
using System.Text;

namespace Infrostructure.Exeption
{
   public class InvalidDeviceTypeExeption:Exception
    {
        public InvalidDeviceTypeExeption(string message = "نوع محصول اشتباه انتخاب شده است"):base(message){}
    }
}
