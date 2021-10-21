using System;
using Infrostructure.Enums;

namespace DomainModel.StatePattern.InstallmentState
{
    public abstract class StateBaseInstallment
    {
        public StateBaseInstallment()
        {
            Id = Guid.NewGuid();
            PlacedDate = DateTime.Now;
        }
        public InstallmentStateEnum InstallmentStateEnum{ get;protected set; }
        public Guid Id{ get;private set; }
        public DateTime PlacedDate{ get; private set; }
    }
}
