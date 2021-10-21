using System;
using DomainModel.Entity.PaymentMethods;
using Infrostructure.Enums;

namespace ApplicationServices.Command
{
    public class PaymentMethodCommand:CommandBase
    {
        public PaymentMethod PaymentMethod { get; set; }
        public PaymentMethodEnum PaymentMethodEnum{ get; set; }
        public InstallmentPaymentTypeEnum InstallmentPaymentType { get; set; }
        public InstallmentCountType InstallmentCount { get; set; }

        public override void Validate()
        {
        }
    }
}
