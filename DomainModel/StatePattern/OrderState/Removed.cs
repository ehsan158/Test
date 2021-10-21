using System;
using Infrostructure.Enums;

namespace DomainModel.StatePattern.OrderState
{
    /// <summary>
    /// لغو شده
    /// </summary>
    public class Removed : StateBase
    {
        public Removed()
        {
            OrderStateEnum = OrderStateEnum.Removed;
        }
    }
}
