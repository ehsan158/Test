using System;

namespace Infrostructure.Exeption
{
    public class InvalidRamMemoryTechnologyException : Exception
    {
        public InvalidRamMemoryTechnologyException(string message = "مقدار خالی وارد شده است") : base(message) { }
    }
}
