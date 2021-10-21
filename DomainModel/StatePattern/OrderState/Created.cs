using System;
using Infrostructure.Enums;

namespace DomainModel.StatePattern.OrderState
{
    /// <summary>
    /// ساخته شده
    /// </summary>
    public class Created : StateBase
    {
        public Created()
        {
            OrderStateEnum = OrderStateEnum.Created;
        }
        public override StateBase RemovedOrder() => new Removed();
    }
}
