using System;

namespace DomainModel.Entity.PaymentMethods
{
    /// <summary>
    /// روش پرداخت 
    /// </summary>
    public class PaymentMethod
    {
        public PaymentMethod()
        {
            Id = Guid.NewGuid();
        }
        /// <summary>
        /// شناسه 
        /// </summary>
        public Guid Id{ get;private set; }
    }
}
