using System;
using ApplicationServices.Exception;
using DomainModel.Entity.AmountClasses;
using DomainModel.Entity.PaymentProducts;

namespace ApplicationServices.Command
{
    public class FinalizePaymentCommnad:CommandBase
    {
        public Amount Cash{ get; set; }
        public Amount PrePayment{ get; set; }
        public override void Validate() {}
    }
}
