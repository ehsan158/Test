using System;
using DomainModel.Entity.AmountClasses;

namespace DomainModel.Entity.PaymentProducts
{
    /// <summary>
    /// پرداخت
    /// </summary>
    public abstract class Payment
    {
        public Payment()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// شناسه
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// مبلغ نقدی
        /// </summary>
        public Amount Cash { get; protected set; }
    }
}
