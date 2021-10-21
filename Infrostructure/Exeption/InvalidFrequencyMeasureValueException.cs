using System;

namespace Infrostructure.Exeption
{
    public class InvalidFrequencyMeasureValueException : Exception
    {
        public InvalidFrequencyMeasureValueException(string message = "مقدار صحیح نمی باشد") : base(message) { }
    }
}
