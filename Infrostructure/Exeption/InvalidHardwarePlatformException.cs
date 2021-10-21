using System;

namespace Infrostructure.Exeption
{
    public class InvalidHardwarePlatformException : Exception
    {
        public InvalidHardwarePlatformException(string message = "مقدار خالی وارد شده است") : base(message) { }
    }
}
