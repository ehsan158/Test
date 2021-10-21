using System;

namespace Infrostructure.Exeption
{
    public class ProductNameEmptyException : Exception
    {
        public ProductNameEmptyException(string message = "مقدار خالی وارد شده است") : base(message) { }
    }
}
