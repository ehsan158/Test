using System;
using System.Collections.Generic;
using System.Text;

namespace Infrostructure.Exeption
{
    public class InvalidOrderIdExeption : Exception
    {
        public InvalidOrderIdExeption(string message = "ایدی سفارش  برای ثبت در یوزر وارد نشده است") : base(message) { }
    }
}
