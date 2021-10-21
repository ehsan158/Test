using System;

namespace Infrostructure.Exeption
{
    public class InvalidCpuManufacturerException : Exception
    {
        public InvalidCpuManufacturerException(string message = "مقدار خالی وارد شده است") : base(message) { }
    }
}
