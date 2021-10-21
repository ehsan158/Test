using System;

namespace Infrostructure.Exeption
{
    public class InvalidMouseOperatingSystemException : Exception
    {
        public InvalidMouseOperatingSystemException(string message = "مقدار خالی وارد شده است") : base(message) { }
    }
}
