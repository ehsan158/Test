using System;

namespace Infrostructure.Exeption
{
    public class InvalidVideoOutputInterfaceException : Exception
    {
        public InvalidVideoOutputInterfaceException(string message = "مقدار خالی وارد شده است") : base(message) { }
    }
}
