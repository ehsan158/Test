using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Tracing;
using System.Linq;
using ApplicationServices.Command;
using ApplicationServices.DTO;
using ApplicationServices.Services.Interfaces;
using DomainModel.Entity.AmountClasses;
using DomainModel.Entity.Cart;
using DomainModel.Entity.DomainServices;
using DomainModel.Entity.PaymentMethods;
using DomainModel.Entity.PaymentProducts;
using DomainModel.StatePattern.InstallmentState;
using DomainModel.StatePattern.OrderState;
using Infrostructure.Enums;
using Infrostructure.ExtensionMethods;
using Repository.Repository.Read.Interfaces;
using Created = DomainModel.StatePattern.OrderState.Created;

namespace ApplicationServices.Services.Implementations
{
    public class OrderServices : IOrderServices
    {
        #region Constructor
        readonly IUserRepositoryRead _userRepositoryRead;
        readonly IOrderRepositoryRead _orderRepositoryRead;
        private readonly PaymentServiceDom _PaymentServiceDom;
        public OrderServices(IUserRepositoryRead userRepositoryRead, IOrderRepositoryRead orderRepositoryRead)
        {
            _userRepositoryRead = userRepositoryRead;
            _orderRepositoryRead = orderRepositoryRead;
            _PaymentServiceDom = new PaymentServiceDom();
        }
        #endregion

        #region Set Payment Method In Order
        public string ValidateForSetPaymentMethod(Guid userId)
        {
            var user = _userRepositoryRead.GetUserById(userId);
            var order = _orderRepositoryRead.GetOrderById(user.OrdersId.LastOrDefault());

            if (order.CurrentState.OrderStateEnum == OrderStateEnum.Bought)
                return "This order is being paid!";

            return order.Products.ToList().Count == 0 ? "Product not selected!" : null;
        }
        public string SetPaymentMethodInOrder(Guid userId, PaymentMethodDto payeMethodDto)
        {
            var user = _userRepositoryRead.GetUserById(userId);
            var order = _orderRepositoryRead.GetOrderById(user.OrdersId.LastOrDefault());

            order.SetPaymentMethod(payeMethodDto.PaymentMethod);
            return "Payment method was selected successfully!";
        }
        #endregion

        #region Finalize Order
        public string ValidateForFinalizeOrder(Guid userId)
        {
            var user = _userRepositoryRead.GetUserById(userId);
            var order = _orderRepositoryRead.GetOrderById(user.OrdersId.LastOrDefault());

            return order.PaymentMethod == null ? "Payment method not selected!" : null;
        }
        public FinalizePaymentDto FinalizeTheOrder(Guid userId)
        {
            var user = _userRepositoryRead.GetUserById(userId);
            var order = _orderRepositoryRead.GetOrderById(user.OrdersId.LastOrDefault());

            var totalPrice = new Amount(order.Products.Sum(c => c.Price.Value));

            if (order.PaymentMethod is InstallmentPaymentMethod installmentPaymentMethod && installmentPaymentMethod.InstallmentPaymentType == InstallmentPaymentTypeEnum.PrePayment)
                return new FinalizePaymentDto() { PrePayment = _PaymentServiceDom.GetPrePayment(totalPrice) };

            else if (order.PaymentMethod is CashPaymentMethod)
                return new FinalizePaymentDto() { Cash = totalPrice };

            return new FinalizePaymentDto() { };
        }
        #endregion

        #region Change The Statuse Of Order
        public void ChangeTheStatusOfTheOrderDueToPayment(Guid userId, FinalizePaymentCommnad finalizePaymentCommnad)
        {
            var user = _userRepositoryRead.GetUserById(userId);
            var order = _orderRepositoryRead.GetOrderById(user.OrdersId.LastOrDefault());

            if (finalizePaymentCommnad.Cash != null)
                order.CheckOutOrder();

            order.SetPayment();
        }
        #endregion

        #region Change The Status Of Installment
        public void ChangeTheStatusOfTheInstallment(Guid userId, InstallmentCommand installmentCommand)
        {
            var user = _userRepositoryRead.GetUserById(userId);
            var order = _orderRepositoryRead.GetOrderById(user.OrdersId.LastOrDefault());

            installmentCommand.Installment.PaidInstallment();

            CheckTheStatusOfAllInstallments(order);
        }
        #endregion

        #region Check The Status Of Installments
        private void CheckTheStatusOfAllInstallments(Order order)
        {
            if (order.Payment is InstallmentPayment installmentPayment && installmentPayment.Installments.All(c => c.CurrentState is Paid))
            {
                order.CheckOutOrder();
            }
        }
        #endregion

        #region Check For Paid Order
        public bool CheckPaidOrder(Guid userId)
        {
            var user = _userRepositoryRead.GetUserById(userId);
            var order = _orderRepositoryRead.GetOrderById(user.OrdersId.LastOrDefault());

            if (order.CurrentState.OrderStateEnum == OrderStateEnum.CheckOut || order.CurrentState.OrderStateEnum == OrderStateEnum.Removed)
                return true;
            return false;
        }
        #endregion

        #region Cancle Order
        public string ValidateForCancleOrder(Guid userId, string result)
        {
            var user = _userRepositoryRead.GetUserById(userId);
            var order = _orderRepositoryRead.GetOrderById(user.OrdersId.LastOrDefault());

            if (result != "y")
                return "";

            if (order.CurrentState.OrderStateEnum == OrderStateEnum.CheckOut || order.CurrentState.OrderStateEnum == OrderStateEnum.Bought)
                return "You can not cancel your order!";

            return null;
        }
        public string CancleOrder(Guid userId)
        {
            var user = _userRepositoryRead.GetUserById(userId);
            var order = _orderRepositoryRead.GetOrderById(user.OrdersId.LastOrDefault());

            order.RemovedOrder();
            return "Order canceled!";
        }
        #endregion

        #region Get Description State
        public string GetDescriptionState(Guid userId)
        {
            var user = _userRepositoryRead.GetUserById(userId);
            var order = _orderRepositoryRead.GetOrderById(user.OrdersId.LastOrDefault());

            return order.CurrentState.OrderStateEnum.GetDescription();
        }
        #endregion
    }
}
