using System;
using Infrostructure.Enums;

namespace DomainModel.StatePattern.OrderState
{
    public abstract class StateBase
    {
        public StateBase()
        {
            Id = Guid.NewGuid();
            PlacedDate = DateTime.Now;
        }
        public OrderStateEnum OrderStateEnum { get;protected set; }
        public Guid Id{ get;private set; }
        public DateTime PlacedDate{ get; private set; }
        public virtual StateBase GeneratePaymentMethod() => throw new InvalidOperationException();
        public virtual StateBase CheckOutOrder() => throw new InvalidOperationException();
        public virtual StateBase RemovedOrder() => throw new InvalidOperationException();
    }
}
