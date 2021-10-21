using System;
using DomainModel.Entity.AmountClasses;
using Infrostructure.Exeption;

namespace DomainModel.Entity.PaymentProducts
{
    /// <summary>
    /// پرداخت نقدی
    /// </summary>
    public class CashPayment:Payment
    {
        public CashPayment(Amount cash)
        {
            ValidateForCashAmount(cash);

            Cash = cash;
            DatePaid = DateTime.Now;
        }

        /// <summary>
        /// تاریخ پرداخت 
        /// </summary>
        public DateTime DatePaid { get; private set; }

        //Validations
        private void ValidateForCashAmount(Amount cash)
        {
            if (cash == null)
                throw new InvalidCashAmountExeption();
        }
    }
}
