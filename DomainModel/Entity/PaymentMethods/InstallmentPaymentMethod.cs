using System;
using Infrostructure.Enums;
using Infrostructure.Exeption;

namespace DomainModel.Entity.PaymentMethods
{
    /// <summary>
    /// روش پرداخت اقساطی
    /// </summary>
    public class InstallmentPaymentMethod:PaymentMethod
    {
        /// <summary>
        /// تعداد ماه
        /// </summary>
        public InstallmentCountType InstallmentCount { get;private set; }

        /// <summary>
        /// نوع پرداخت قسطی
        /// </summary>
        public InstallmentPaymentTypeEnum InstallmentPaymentType { get;private set; }

        public InstallmentPaymentMethod(InstallmentCountType installmentCount, InstallmentPaymentTypeEnum installmentPaymentType)
        {
            InstallmentCount = installmentCount;
            InstallmentPaymentType = installmentPaymentType;
        }
    }
}
