using System;
using ApplicationServices.Exception;
using DomainModel.Entity.PaymentProducts;
using DomainModel.Entity.PaymentType;

namespace ApplicationServices.Command
{
   public class InstallmentCommand:CommandBase
    {
        public InstallmentPayment InstallmentPayment { get; set; }
        public Installment Installment { get; set; }
        public override void Validate()
        {
            if (InstallmentPayment == null)
                throw new InvalidInstallmentPaymentExeption();
            if (Installment == null)
                throw new InvalidInstallmentExeption();
        }
    }
}
