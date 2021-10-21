using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationServices.Exception
{
    public class InvalidUserInformationExeption : System.Exception
    {
        public InvalidUserInformationExeption(string message = "اطلاعات کاربر برای ورود معتبر نمی باشد") : base(message) { }
    }
}
