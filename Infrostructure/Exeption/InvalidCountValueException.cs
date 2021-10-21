using System;

namespace Infrostructure.Exeption
{
   public class InvalidCountValueException : Exception
    {
        public InvalidCountValueException(string message = "تعداد صحیح نمی باشد") : base(message) { }
    }
}
