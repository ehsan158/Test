using System;
using System.Collections.Generic;
using System.Text;

namespace Infrostructure.Exeption
{
    public class InvalidPenaltyExeption : Exception
    {
        public InvalidPenaltyExeption(string message = "مقدار خالی وارد شده است") : base(message) { }
    }
}
