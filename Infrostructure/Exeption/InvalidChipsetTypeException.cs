using System;

namespace Infrostructure.Exeption
{
    public class InvalidChipsetTypeException : Exception
    {
        public InvalidChipsetTypeException(string message = "مقدار خالی وارد شده است") : base(message) { }
    }
}
