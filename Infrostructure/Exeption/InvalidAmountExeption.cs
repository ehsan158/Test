using System;

namespace Infrostructure.Exeption
{
    public class InvalidAmountExeption:Exception
    {
        public InvalidAmountExeption(string message = "مبلغ وارد شده صحیح نمی باشد."):base(message){}
    }
}
