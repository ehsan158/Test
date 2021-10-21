using System;

namespace Infrostructure.Exeption
{
   public class InvalidCpuSocketException : Exception
    {
        public InvalidCpuSocketException(string message = "مقدار خالی وارد شده است") : base(message) { }
    }
}
