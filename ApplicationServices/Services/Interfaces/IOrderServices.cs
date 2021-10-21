using System;
using ApplicationServices.Command;
using ApplicationServices.DTO;
using DomainModel.StatePattern.OrderState;
using Infrostructure.Enums;

namespace ApplicationServices.Services.Interfaces
{
    public interface IOrderServices
    {
        public string SetPaymentMethodInOrder(Guid userId, PaymentMethodDto payeMethodDto);
        public string ValidateForSetPaymentMethod(Guid userId);
        public FinalizePaymentDto FinalizeTheOrder(Guid userId);
        public void ChangeTheStatusOfTheOrderDueToPayment(Guid userId, FinalizePaymentCommnad finalizePaymentCommnad);
        public void ChangeTheStatusOfTheInstallment(Guid userId, InstallmentCommand installmentCommand);
        public bool CheckPaidOrder(Guid userId);
        public string CancleOrder(Guid userId);
        public string ValidateForCancleOrder(Guid userId, string result);
        public string ValidateForFinalizeOrder(Guid userId);
        public string GetDescriptionState(Guid userId);
    }
}
