using System;
using System.Collections.Generic;
using System.Text;

namespace Infrostructure.Exeption
{
    public class InvalidComisionExeption : Exception
    {
        public InvalidComisionExeption(string message = "مقدار خالی وارد شده است") : base(message) { }
    }
}
