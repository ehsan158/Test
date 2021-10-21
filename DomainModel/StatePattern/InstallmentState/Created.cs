using System;
using Infrostructure.Enums;

namespace DomainModel.StatePattern.InstallmentState
{
    /// <summary>
    /// ساخته شده
    /// </summary>
    public class Created: StateBaseInstallment
    {
        public Created()
        {
            InstallmentStateEnum = InstallmentStateEnum.Created;
        }
    }
}
