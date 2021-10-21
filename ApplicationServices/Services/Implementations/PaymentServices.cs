using System;
using System.Linq;
using ApplicationServices.Command;
using ApplicationServices.DTO;
using ApplicationServices.Services.Interfaces;
using DomainModel.Entity.AmountClasses;
using DomainModel.Entity.DomainServices;
using DomainModel.Entity.PaymentMethods;
using DomainModel.Entity.PaymentProducts;
using DomainModel.StatePattern.InstallmentState;
using DomainModel.StatePattern.OrderState;
using Infrostructure.Enums;
using Repository.Repository.Read.Interfaces;

namespace ApplicationServices.Services.Implementations
{
    public class PaymentServices : IPaymentServices
    {
        #region Constructor
        readonly IOrderRepositoryRead _orderRepositoryRead;
        readonly IUserRepositoryRead _userRepositoryRead;
        private readonly PaymentServiceDom _paymentServiceDom;

        public PaymentServices(IOrderRepositoryRead orderRepositoryRead, IUserRepositoryRead userRepositoryRead, PaymentServiceDom paymentServiceDom)
        {
            _orderRepositoryRead = orderRepositoryRead;
            _userRepositoryRead = userRepositoryRead;
            _paymentServiceDom = paymentServiceDom;
        }
        #endregion

        #region Get Payment Method
        public PaymentMethodDto GetPaymentMethod(Guid userId, PaymentMethodCommand paymentMethodCommand)
        {
            if (paymentMethodCommand.PaymentMethodEnum == PaymentMethodEnum.Cash)
                return new PaymentMethodDto() { PaymentMethod = new CashPaymentMethod() };

            var user = _userRepositoryRead.GetUserById(userId);
            var order = _orderRepositoryRead.GetOrderById(user.OrdersId.LastOrDefault());

            var totalPrice = order.Products.Sum(c => c.Price.Value);

            var installmentPaymentMethod = new InstallmentPaymentMethod(paymentMethodCommand.InstallmentCount, paymentMethodCommand.InstallmentPaymentType);

            return new PaymentMethodDto() { PaymentMethod = installmentPaymentMethod };

        }
        #endregion

        #region Get Installments Details
        public string ValidateForPayment(Guid userId)
        {
            var user = _userRepositoryRead.GetUserById(userId);
            var order = _orderRepositoryRead.GetOrderById(user.OrdersId.LastOrDefault());

            var paymentMethod = order.PaymentMethod;
            var totalPrice = order.Products.Sum(c => c.Price.Value);

            if (paymentMethod == null)
                return "\nPayment method not selected";

            return paymentMethod is CashPaymentMethod ? "\nCash payment method selected\nTotal Price is : " + totalPrice : null;
        }

        public PaymentDto GetInstallmentPaymentDetails(Guid userId)
        {
            var user = _userRepositoryRead.GetUserById(userId);
            var order = _orderRepositoryRead.GetOrderById(user.OrdersId.LastOrDefault());
            var payment = order.Payment;

            if (payment != null)
            {
                var installmentPayment = (InstallmentPayment)payment;
                var installments = installmentPayment.Installments.ToList();
                var totalPriceForShow = new Amount(installments.Sum(c => ((c.InstallmentAmount + c.Comision) + c.Penalty).Value));

                totalPriceForShow += installmentPayment.Cash ?? new Amount(0);

                return new PaymentDto()
                {
                    Installments = installments,
                    Cash = installmentPayment.Cash,
                    TotalPrice = totalPriceForShow
                };
            }

            else
            {
                var totalPrice = new Amount(order.Products.Sum(c => c.Price.Value));
                var installmentPaymentMethod = (InstallmentPaymentMethod)order.PaymentMethod;
                var installmentPayment = new InstallmentPayment(_paymentServiceDom);
                installmentPayment.CreateInstallments(totalPrice, installmentPaymentMethod.InstallmentCount,
                    installmentPaymentMethod.InstallmentPaymentType);
                var installments = installmentPayment.Installments.ToList();

                var totalPriceForShow =
                    new Amount(installments.Sum(c => ((c.InstallmentAmount + c.Comision) + c.Penalty).Value));

                totalPriceForShow += installmentPayment.Cash ?? new Amount(0);

                return new PaymentDto()
                {
                    Installments = installments,
                    Cash = installmentPayment.Cash,
                    TotalPrice = totalPriceForShow
                };
            }
        }
        #endregion

        #region Payment Of Installments
        public string ValidateForInstallment(Guid userId)
        {
            var user = _userRepositoryRead.GetUserById(userId);
            var order = _orderRepositoryRead.GetOrderById(user.OrdersId.LastOrDefault());

            var paymentMethod = order.PaymentMethod;
            var payment = order.Payment;


            if (paymentMethod == null)
                return "payment method not selected!";

            if (paymentMethod is CashPaymentMethod)
                return "Cash Payment method selected!";

            if (payment == null)
                return "Please finalize your order";

            return null;
        }
        public InstallmentDto PaymentOfInstallments(Guid userId)
        {
            var user = _userRepositoryRead.GetUserById(userId);
            var order = _orderRepositoryRead.GetOrderById(user.OrdersId.LastOrDefault());

            var payment = order.Payment;

            var installmentPayment = (InstallmentPayment)payment;
            var installmentForPayment = installmentPayment.Installments.Where(c => c.CurrentState is not Paid).ToList().First();
            installmentForPayment.SetPenalty();

            return new InstallmentDto() { Installment = installmentForPayment, InstallmentPayment = installmentPayment };
        }
        #endregion
    }
}
