using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using DomainModel.Entity.AmountClasses;
using DomainModel.Entity.DomainServices;
using DomainModel.Entity.PaymentMethods;
using DomainModel.Entity.PaymentProducts;
using DomainModel.Entity.product;
using DomainModel.StatePattern.OrderState;
using Infrostructure.Exeption;

namespace DomainModel.Entity.Cart
{
    /// <summary>
    /// سفارش
    /// </summary>
    public class Order
    {
        public Order(IEnumerable<Product> products)
        {
            ValidateForProductList(products);
            Id = Guid.NewGuid();
            Products = products;
            AddState(new Created());
        }
        /// <summary>
        /// شناسه 
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// لیست محصولات
        /// </summary>
        public IEnumerable<Product> Products { get; private set; }
        /// <summary>
        /// اطلاعات مربوط به پرداخت
        /// </summary>
        public Payment Payment { get; private set; }
        /// <summary>
        /// اطلاعات مربوط به روش پرداخت
        /// </summary>
        public PaymentMethod PaymentMethod { get; private set; }

        /// <summary>
        /// تاریخچه حالات
        /// </summary>
        public IEnumerable<StateBase> StateBaseHistory { get; private set; } = new List<StateBase>();
        /// <summary>
        /// حالت 
        /// </summary>
        public StateBase CurrentState => StateBaseHistory.OrderByDescending(s => s.PlacedDate).FirstOrDefault();

        public void SetPaymentMethod(PaymentMethod paymentMethod)
        {
            ValidateForPaymentMethod(paymentMethod);

            PaymentMethod = paymentMethod;
        }
        public void SetPayment()
        {
            var totalPrice = new Amount(Products.Sum(c => c.Price.Value));
            if (PaymentMethod is InstallmentPaymentMethod installmentPaymentMethod)
            {
                var installmentPayment = new InstallmentPayment(new PaymentServiceDom());

                installmentPayment.CreateInstallments(totalPrice, installmentPaymentMethod.InstallmentCount, installmentPaymentMethod.InstallmentPaymentType);
                ValidateForPayment(installmentPayment);

                Payment = installmentPayment;
                BoughtOrder();
            }
            else
            {
                var cashPayment = new CashPayment(totalPrice);
                ValidateForPayment(cashPayment);
                Payment = cashPayment;
            }
        }
        public void CheckOutOrder()
        {
            AddState(new Checkout());
        }
        public bool RemovedOrder()
        {
            if (CurrentState is Checkout || CurrentState is Bought)
                return false;

            AddState(new Removed());
            return true;
        }
        public void BoughtOrder()
        {
            AddState(new Bought());
        }
        public bool AddProducts(IEnumerable<Product> productsForAdd)
        {
            ValidateForProductList(productsForAdd);
            if (!(CurrentState is Checkout) && !(CurrentState is Bought))
            {
                var products = Products.ToList();

                products.AddRange(productsForAdd);

                Products = products;

                return true;
            }
            return false;
        }
        public bool RemoveProduct(Product product)
        {
            if (!(CurrentState is Checkout) && !(CurrentState is Bought))
            {
                var products = Products.Where(c => c.Id != product.Id).ToList();
                Products = products;

                return true;
            }
            return false;
        }
        private void AddState(StateBase stateBase)
        {
            var stateBases = StateBaseHistory.ToList();
            stateBases.Add(stateBase);
            StateBaseHistory = stateBases;
        }

        //Validations
        private void ValidateForProductList(IEnumerable<Product> products)
        {
            var temp = products.ToList();
            if (!temp.Any() && temp.Count == 0)
                throw new InvalidProductsExeption();
        }
        private void ValidateForPayment(Payment payment)
        {
            if (payment is CashPayment && payment.Cash == null)
            {
                throw new InvalidCashPaymentException();
            }
            else if (payment is InstallmentPayment installmentPayment && installmentPayment.Installments.Any() && installmentPayment.Installments.ToList().Count == 0)
            {
                throw new InvalidInstallmentPaymentExeption();
            }
        }

        private void ValidateForPaymentMethod(PaymentMethod paymentMethod)
        {
            if (paymentMethod == null)
                throw new InvalidPaymentMethodExeption();
        }
    }
}
