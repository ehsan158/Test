using System;

namespace Infrostructure.Exeption
{
   public class InvalidVoltageMeasureValueException : Exception
    {
        public InvalidVoltageMeasureValueException(string message = "مقدار خالی وارد شده است") : base(message) { }
    }
}
