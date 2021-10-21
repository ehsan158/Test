using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationServices.Exception
{
    public class InvalidInstallmentExeption : System.Exception
    {
        public InvalidInstallmentExeption(string message = "قسط فرستاده شده خالی است") : base(message) { }
    }
}
