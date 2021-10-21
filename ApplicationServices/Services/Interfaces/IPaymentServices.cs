using System;
using ApplicationServices.Command;
using ApplicationServices.DTO;
using Infrostructure.Enums;

namespace ApplicationServices.Services.Interfaces
{
    public interface IPaymentServices
    {
        public PaymentMethodDto GetPaymentMethod(Guid userId, PaymentMethodCommand paymentMethodCommand);
        public PaymentDto GetInstallmentPaymentDetails(Guid userId);
        public InstallmentDto PaymentOfInstallments(Guid userId);
        public string ValidateForPayment(Guid userId);
        public string ValidateForInstallment(Guid userId);
    }
}
