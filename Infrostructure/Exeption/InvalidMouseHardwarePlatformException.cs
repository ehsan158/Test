using System;

namespace Infrostructure.Exeption
{
   public class InvalidMouseHardwarePlatformException : Exception
    {
        public InvalidMouseHardwarePlatformException(string message = "مقدار خالی وارد شده است") : base(message) { }
    }
}
