using DomainModel.Entity.PaymentProducts;
using DomainModel.Entity.PaymentType;

namespace ApplicationServices.DTO
{
    public class InstallmentDto : IDto
    {
        public InstallmentPayment InstallmentPayment { get; set; }
        public Installment Installment { get; set; }
        public string Display()
        {
            return $"\nInstallment amount : {((Installment.InstallmentAmount + Installment.Comision) + Installment.Penalty).Value }\nPay Date : {Installment.PayDate.ToString()}";
        }
    }
}
