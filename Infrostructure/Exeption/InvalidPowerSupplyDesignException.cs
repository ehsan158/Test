using System;

namespace Infrostructure.Exeption
{
    public class InvalidPowerSupplyDesignException : Exception
    {
        public InvalidPowerSupplyDesignException(string message = "مقدار خالی وارد شده است") : base(message) { }
    }
}
