using System;

namespace Infrostructure.Exeption
{
   public class InvalidLengthMeasureValueException : Exception
    {
        public InvalidLengthMeasureValueException(string message = "عرض صحیح نمی باشد") : base(message) { }
    }
}
