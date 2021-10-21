using System;
using System.Collections.Generic;
using DomainModel.Entity.AmountClasses;
using DomainModel.Entity.DomainServices;
using DomainModel.Entity.PaymentType;
using Infrostructure.Enums;
using Infrostructure.Exeption;

namespace DomainModel.Entity.PaymentProducts
{
    /// <summary>
    /// پرداخت قسطی
    /// </summary>
    public class InstallmentPayment : Payment
    {
        private readonly PaymentServiceDom _paymentServiceDom;

        public InstallmentPayment(PaymentServiceDom paymentServiceDom)
        {
            this._paymentServiceDom = paymentServiceDom;
        }

        /// <summary>
        /// اقساط
        /// </summary>
        public IEnumerable<Installment> Installments { get; private set; }

        public void CreateInstallments(Amount totalPrice, InstallmentCountType insatallmentCount, InstallmentPaymentTypeEnum installmentPaymentType)
        {
            var installmentCountValue = (int)insatallmentCount;

            if (installmentPaymentType == InstallmentPaymentTypeEnum.WithOutPrePayment)
                Installments = _paymentServiceDom.WithOutPrePaymentMethod(totalPrice, installmentCountValue);

            else
            {
                Installments = _paymentServiceDom.PrePaymentMethod(totalPrice, installmentCountValue);
                Cash = _paymentServiceDom.GetPrePayment(totalPrice);
            }
        }
    }
}
