using System;
using Infrostructure.Enums;

namespace DomainModel.StatePattern.OrderState
{
    /// <summary>
    /// تسویه حساب شده
    /// </summary>
    public class Checkout : StateBase
    {
        public Checkout()
        {
            OrderStateEnum = OrderStateEnum.CheckOut;
        }
    }
}
