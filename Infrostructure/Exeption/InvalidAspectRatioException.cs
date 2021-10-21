using System;

namespace Infrostructure.Exeption
{
   public class InvalidAspectRatioException : Exception
    {
        public InvalidAspectRatioException(string message = "مقدار خالی وارد شده است") : base(message) { }
    }
}
