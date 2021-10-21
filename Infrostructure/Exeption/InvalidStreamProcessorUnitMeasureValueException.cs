using System;

namespace Infrostructure.Exeption
{
   public class InvalidStreamProcessorUnitMeasureValueException : Exception
    {
        public InvalidStreamProcessorUnitMeasureValueException(string message = "مقدار خالی وارد شده است") : base(message) { }
    }
}
