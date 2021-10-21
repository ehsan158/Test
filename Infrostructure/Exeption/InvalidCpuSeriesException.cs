using System;

namespace Infrostructure.Exeption
{
    public class InvalidCpuSeriesException : Exception
    {
        public InvalidCpuSeriesException(string message = "مقدار خالی وارد شده است") : base(message) { }
    }
}
