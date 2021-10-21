using System;

namespace Infrostructure.Exeption
{
    public class InvalidWattageMeasureValueException :Exception
    {
        public InvalidWattageMeasureValueException(string message = "مقدار خالی وارد شده است") : base(message) { }
    }
}
