using System;
using Infrostructure.Enums;

namespace DomainModel.StatePattern.OrderState
{
    /// <summary>
    /// خریداری شده
    /// </summary>
    public class Bought:StateBase
    {
        public Bought()
        {
            OrderStateEnum = OrderStateEnum.Bought;
        }
    }
}
