using System;

namespace Infrostructure.Exeption
{
   public class InvalidWeightMeasureValueException : Exception
    {
        public InvalidWeightMeasureValueException(string message = "مقدار خالی وارد شده است") : base(message) { }
    }
}
