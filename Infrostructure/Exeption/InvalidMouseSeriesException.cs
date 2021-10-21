using System;

namespace Infrostructure.Exeption
{
   public class InvalidMouseSeriesException : Exception
    {
        public InvalidMouseSeriesException(string message = "مقدار خالی وارد شده است") : base(message) { }
    }
}
