using Infrostructure.Enums;

namespace Infrostructure.ExtensionMethods
{
   public static class GetInstallmentPaymentTypeExtensionMethod
    {
        public static InstallmentPaymentTypeEnum GetInstallmentPaymentType(this int value)
        {
            if (value == 1)
                return InstallmentPaymentTypeEnum.PrePayment;
            else
                return InstallmentPaymentTypeEnum.WithOutPrePayment;
        }
    }
}
