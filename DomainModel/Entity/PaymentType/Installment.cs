using System;
using System.Collections.Generic;
using System.Linq;
using DomainModel.Entity.AmountClasses;
using DomainModel.StatePattern.InstallmentState;
using Infrostructure.Exeption;

namespace DomainModel.Entity.PaymentType
{
    /// <summary>
    /// قسط
    /// </summary>
    public class Installment
    {
        public Installment(Amount installmentAmount, DateTime payDate)
        {
            ValidateForInstallmentAmount(installmentAmount);

            Id = Guid.NewGuid();
            InstallmentAmount = installmentAmount;
            PayDate = payDate;
            AddState(new Created());
        }

        /// <summary>
        /// شناسه
        /// </summary>
        public Guid Id { get; private set; }
        /// <summary>
        /// مبلغ قسط
        /// </summary>
        public Amount InstallmentAmount { get; private set; }
        /// <summary>
        /// مبلغ جریمه
        /// </summary>
        public Amount Penalty { get; private set; } = new Amount(0);
        /// <summary>
        /// تاریخ پرداخت
        /// </summary>
        public DateTime PayDate { get; private set; }
        /// <summary>
        /// مبلغ سود
        /// </summary>
        public Amount Comision { get; private set; } = new Amount(0);

        /// <summary>
        /// تاریخچه حالات
        /// </summary>
        public IEnumerable<StateBaseInstallment> StateBaseHistory { get; private set; } = new List<StateBaseInstallment>();
        /// <summary>
        /// حالت
        /// </summary>
        public StateBaseInstallment CurrentState => StateBaseHistory.OrderByDescending(s => s.PlacedDate).FirstOrDefault();
        public void SetComision(Amount comision)
        {
            ValidateForComision(comision);

            Comision = comision;
        }
        public void SetPenalty()
        {
            int index = 0;
            var today = DateTime.Now;
            if (today > PayDate)
            {
                if (today.Year == PayDate.Year)
                {
                    index = today.DayOfYear - PayDate.DayOfYear;
                }
                else if (today.Year > PayDate.Year)
                {
                    if (today.DayOfYear < PayDate.DayOfYear || today.DayOfYear > PayDate.DayOfYear)
                    {
                        index = today.DayOfYear - (365 - PayDate.DayOfYear);
                    }
                    if (today.DayOfYear == PayDate.DayOfYear)
                    {
                        index = 365;
                    }
                }
                for (int i = 1; i <= index; i++)
                {
                   var penalty = InstallmentAmount.Division(100).Multiplication(2 * i);
                   ValidateForPenalty(penalty);
                   Penalty = penalty;
                }
            }
        }
        public void PaidInstallment()
        {
            AddState(new Paid());
        }
        private void AddState(StateBaseInstallment stateBase)
        {
            var stateBases = StateBaseHistory.ToList();
            stateBases.Add(stateBase);
            StateBaseHistory = stateBases;
        }

        //Validations
        private void ValidateForInstallmentAmount(Amount installmentAmount)
        {
            if (installmentAmount == null)
                throw new InvalidInstallmentAmountExeption();
        }

        private void ValidateForPenalty(Amount penalty)
        {
            if (penalty == null)
                throw new InvalidPenaltyExeption();
        }
        private void ValidateForComision(Amount comision)
        {
            if (comision == null)
                throw new InvalidComisionExeption();
        }
    }
}
