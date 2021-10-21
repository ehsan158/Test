using System;

namespace Infrostructure.Exeption
{
    public class InvalidRamSizeMeasureValueException : Exception
    {
        public InvalidRamSizeMeasureValueException(string message = "مقدار خالی وارد شده است") : base(message) { }
    }
}
