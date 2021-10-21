using System;

namespace Infrostructure.Exeption
{
    public class InvalidSpeedMeasureValueException : Exception
    {
        public InvalidSpeedMeasureValueException(string message = "مقدار خالی وارد شده است") : base(message){}
    }
}
