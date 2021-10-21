using System;

namespace Infrostructure.Exeption
{
   public class InvalidOperatingSystemException : Exception
    {
        public InvalidOperatingSystemException(string message = "مقدار خالی وارد شده است") : base(message) { }
    }
}
