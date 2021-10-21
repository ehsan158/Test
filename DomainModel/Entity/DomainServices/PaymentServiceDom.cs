using System;
using System.Collections.Generic;
using DomainModel.Entity.AmountClasses;
using DomainModel.Entity.PaymentType;

namespace DomainModel.Entity.DomainServices
{
    public class PaymentServiceDom
    {
        public List<Installment> PrePaymentMethod(Amount totalPrice, int installmentCount)
        {
            var installments = new List<Installment>();
            var prePayment = totalPrice.Division(100).Multiplication(20);

            var totalWithOutPrePayment = totalPrice - prePayment;

            var priceForEachInstallment = totalPrice.Division(installmentCount);

            for (int i = 1; i <= installmentCount; i++)
            {
                var installment = new Installment(priceForEachInstallment, CreateDate(i));
                installment.SetComision(priceForEachInstallment.Division(100).Multiplication(2 * i));
                installments.Add(installment);
            }

            return installments;
        }
        public List<Installment> WithOutPrePaymentMethod(Amount totalPrice, int installmentCount)
        {
            var installments = new List<Installment>();
            var priceForEachInstallment = totalPrice.Division(installmentCount);

            for (int i = 1; i <= installmentCount; i++)
            {
                var installment = new Installment(priceForEachInstallment, CreateDate(i));
                installment.SetComision(priceForEachInstallment.Division(100).Multiplication(4*i));
                installments.Add(installment);
            }

            return installments;
        }
        private DateTime CreateDate(int indexMonth)
        {
            var dateTime = DateTime.Now;
            dateTime = dateTime.AddMonths(indexMonth);
            return dateTime;
        }

        public Amount GetPrePayment(Amount totalPrice)
        {
            return totalPrice.Division(100).Multiplication(20);
        }
    }
}
