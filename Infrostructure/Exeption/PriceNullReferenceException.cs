using System;

namespace Infrostructure.Exeption
{
   public class PriceNullReferenceException : Exception
    {
        public PriceNullReferenceException(string message = "مقدار خالی وارد شده است") : base(message) { }
    }
}
