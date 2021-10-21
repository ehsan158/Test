using System.Collections.Generic;
using DomainModel.Entity.AmountClasses;
using DomainModel.Entity.PaymentType;

namespace ApplicationServices.DTO
{
    public class PaymentDto:IDto
    {
        public List<Installment> Installments { get; set; }
        public Amount Cash{ get; set; }
        public Amount TotalPrice { get; set; }
        public string Display()
        {
            var text = $"\nInstallment payment method selected \nTotal price is :{TotalPrice.Value}";
            if (Cash != null)
                text = text + $"\nPre payment amount is :{Cash.Value} \nTotal price with out pre payment is : {(TotalPrice - Cash).Value}";
            for (var i = 1; i <= Installments.Count; i++)
            {
                var item = Installments[i-1];
                text = text + $"\nDate installment {i} : {item.PayDate} \nAmount : { (item.InstallmentAmount + item.Comision).Value}";
            }
            return text;
        }
    }
}
