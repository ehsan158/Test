using System;
using System.Collections.Generic;
using System.Text;

namespace Infrostructure.Exeption
{
    public class InvalidUserDetailsExeption : Exception
    {
        public InvalidUserDetailsExeption(string message = "مقدار خالی وارد شده است") : base(message) { }
    }
}
