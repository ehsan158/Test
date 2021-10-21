using System;

namespace Infrostructure.Exeption
{
    public class DeviceNullReferenceException : Exception
    {
        public DeviceNullReferenceException(string message = "مقدار خالی وارد شده است") : base(message) { }
    }
}
