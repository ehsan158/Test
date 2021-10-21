using System;

namespace Infrostructure.Exeption
{
   public class InvalidGraphicsProcessorManufacturerException : Exception
    {
        public InvalidGraphicsProcessorManufacturerException(string message = "مقدار خالی وارد شده است") : base(message) { }
    }
}
