using System;

namespace Infrostructure.Exeption
{
    public class InvalidOperation:Exception
    {
        public InvalidOperation(string message = "عملیات جاری در این وضعیت امکان پذیر نمی باشد.") : base(message) { }
    }
}
