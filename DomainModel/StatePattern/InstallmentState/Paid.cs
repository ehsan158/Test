using System;
using Infrostructure.Enums;

namespace DomainModel.StatePattern.InstallmentState
{
    /// <summary>
    /// پرداخت شده
    /// </summary>
    public class Paid:StateBaseInstallment
    {
        public Paid()
        {
            InstallmentStateEnum = InstallmentStateEnum.Paid;
        }
    }
}
