using System;
using System.ComponentModel.Design;
using ApplicationServices.Command;
using ApplicationServices.DTO;
using ApplicationServices.Services.Interfaces;
using DomainModel.Entity.PaymentProducts;
using Infrostructure;
using Infrostructure.Enums;

namespace FinoProject.Controller
{
    public class OrderController
    {
        #region Constructor

        private readonly IOrderServices _orderServices;
        private readonly IPaymentServices _paymentServices;

        public OrderController(IOrderServices orderServices, IPaymentServices paymentServices)
        {
            this._orderServices = orderServices;
            this._paymentServices = paymentServices;
        }

        #endregion

        #region Finalize Order
        //Get
        public void GetFinalizeTheOrder()
        {
            var userId = AuthenticationInformation.UserId;
            var message = _orderServices.ValidateForFinalizeOrder(userId);
            if (message != null) PrintMessage(message);
            else
            {
                var result = _orderServices.FinalizeTheOrder(userId);
                ShowForFinalizePayment(result);
                QuestionForFinalizePayment(result);
            }
        }
        //Post
        public void PaidOrder(FinalizePaymentCommnad finalizePaymentCommnad)
        {
            finalizePaymentCommnad.Validate();

            _orderServices.ChangeTheStatusOfTheOrderDueToPayment(AuthenticationInformation.UserId, finalizePaymentCommnad);
        }
        #endregion

        #region Check Paid Order
        public bool CheckPaidOrder()
        {
            return _orderServices.CheckPaidOrder(AuthenticationInformation.UserId);
        }
        #endregion

        #region Cancle Order
        public void CancleOrder()
        {
            var userId = AuthenticationInformation.UserId;

            var result = OrderCancellationQuestion();

            var message = _orderServices.ValidateForCancleOrder(userId, result);
            if (message != null) PrintMessage(message);
            else
            {
                var res = _orderServices.CancleOrder(userId);
                PrintMessage(res);
            }
        }
        #endregion

        #region Get Description State

        public string GetDescriptionState()
        {
            return _orderServices.GetDescriptionState(AuthenticationInformation.UserId);
        }

        #endregion

        #region View
        private void ShowForFinalizePayment(IDto dto)
        {
            Console.WriteLine(dto.Display());
        }
        private void QuestionForFinalizePayment(IDto dto)
        {
            var finalizeDto = (FinalizePaymentDto)dto;

            while (true)
            {
                Console.WriteLine("Please Enter Payment code :");
                if (Console.ReadLine() == "1")
                    break;
                Console.WriteLine("Payment code is not valid!");
            }

            if (finalizeDto.Cash != null)
            {
                Console.WriteLine("Your order has been paid successfully!");
                PaidOrder(new FinalizePaymentCommnad() { Cash = finalizeDto.Cash });
            }
            else if (finalizeDto.PrePayment != null)
            {
                Console.WriteLine("The pre payment amount was paid successfully!");
                PaidOrder(new FinalizePaymentCommnad() { PrePayment = finalizeDto.PrePayment });
            }
            else
                PaidOrder(new FinalizePaymentCommnad() { });
        }

        private void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        private string OrderCancellationQuestion()
        {
            Console.WriteLine("Do you want cancle order?(y/n)");
            return Console.ReadLine();
        }
        #endregion
    }
}
