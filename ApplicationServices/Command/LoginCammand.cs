using System;
using ApplicationServices.Exception;
using DomainModel.Entity.PaymentProducts;
using DomainModel.Entity.PaymentType;

namespace ApplicationServices.Command
{
   public class LoginCammand:CommandBase
    {
        public string UserName{ get; set; }
        public string Password { get; set; }
        public override void Validate()
        {
            if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password) || string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(Password))
                throw new InvalidUserInformationExeption();
        }
    }
}
