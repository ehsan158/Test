using System;

namespace Infrostructure.Exeption
{
    public class LackOfInventoryOrderExeption:Exception
    {
        public LackOfInventoryOrderExeption(string message = "سفارش لغو نشده یا پرداخت نشده ای موجود نیست.") : base(message) { }
    }
}
