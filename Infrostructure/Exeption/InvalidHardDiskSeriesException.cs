using System;

namespace Infrostructure.Exeption
{
    public class InvalidHardDiskSeriesException : Exception
    {
        public InvalidHardDiskSeriesException(string message = "مقدار خالی وارد شده است") : base(message) { }
    }
}
