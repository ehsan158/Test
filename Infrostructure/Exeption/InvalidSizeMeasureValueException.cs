using System;

namespace Infrostructure.Exeption
{
   public class InvalidSizeMeasureValueException : Exception
    {
        public InvalidSizeMeasureValueException(string message = "مقدار خالی وارد شده است") : base(message) { }
    }
}
