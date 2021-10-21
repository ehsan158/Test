using System;
using System.Reflection.Metadata.Ecma335;
using ApplicationServices.Command;
using ApplicationServices.DTO;
using ApplicationServices.Services.Interfaces;
using Infrostructure;
using Infrostructure.Enums;
using Infrostructure.ExtensionMethods;

namespace FinoProject.Controller
{
    public class PaymentController
    {
        #region Constructor
        private readonly IOrderServices _orderServices;
        private readonly IPaymentServices _paymentServices;

        public PaymentController(IOrderServices orderServices, IPaymentServices paymentServices)
        {
            this._orderServices = orderServices;
            this._paymentServices = paymentServices;
        }
        #endregion

        #region PaymentMethod
        //Get
        public void GetPaymentMethod()
        {
            var message = _orderServices.ValidateForSetPaymentMethod(AuthenticationInformation.UserId);
            if (message != null)
                PrintMessage(message);
            else
                GetPaymentMethodFromClient();
        }
        //Post
        private void RegisterPaymentMethod(PaymentMethodCommand paymentMethodCommand)
        {
            var userId = AuthenticationInformation.UserId;

            paymentMethodCommand.Validate();

            var result = _paymentServices.GetPaymentMethod(userId, paymentMethodCommand);
            var validateResult = _orderServices.SetPaymentMethodInOrder(userId, result);
            PrintMessage(validateResult);
        }
        #endregion

        #region Payment Of Installments
        //Get
        public void PaymentOfInstallments()
        {
            var userId = AuthenticationInformation.UserId;

            var message = _paymentServices.ValidateForInstallment(userId);
            if (message != null) PrintMessage(message);
            else
            {
                var result = _paymentServices.PaymentOfInstallments(userId);
                ShowInstallment(result);
                PaymentInstallment(result);
            }
        }

        //Post
        private void ChangeTheStatusOfTheInstallment(InstallmentCommand installmentCommand)
        {
            installmentCommand.Validate();

            _orderServices.ChangeTheStatusOfTheInstallment(AuthenticationInformation.UserId, installmentCommand);
        }
        #endregion

        #region Installment Payment Detail
        //Get
        public void GetInstallmentPaymentDetail()
        {
            var userId = AuthenticationInformation.UserId;
            var message = _paymentServices.ValidateForPayment(userId);

            if (message != null)
                PrintMessage(message);
            else
            {
                var result = _paymentServices.GetInstallmentPaymentDetails(userId);
                ShowInstallmentPaymentDetail(result);
            }
        }
        #endregion

        #region View
        //View
        private void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
        private void GetPaymentMethodFromClient()
        {
            Console.WriteLine("\nChoose Payment Method\n1.Cash\n2.Installment");
            var paymentMethodEnum = (PaymentMethodEnum)Enum.ToObject(typeof(PaymentMethodEnum), Console.ReadLine().HandleInput());

            if (paymentMethodEnum == PaymentMethodEnum.Installment)
            {
                Console.WriteLine("\nChoose Month\n12\n24\n36");
                var installmentCount = (InstallmentCountType)Enum.ToObject(typeof(InstallmentCountType), Console.ReadLine().HandleInput());

                Console.WriteLine("\nSelect a payment method \n 1.with out Pre Payment\n2.With Pre Payment");
                var installmentPaymentType = (InstallmentPaymentTypeEnum)Enum.ToObject(typeof(InstallmentPaymentTypeEnum), Console.ReadLine().HandleInput());

                var paymentMethodCommand = new PaymentMethodCommand() { PaymentMethodEnum = paymentMethodEnum, InstallmentPaymentType = installmentPaymentType, InstallmentCount = installmentCount };
                RegisterPaymentMethod(paymentMethodCommand);
            }
            else
            {
                var paymentMethodCommand = new PaymentMethodCommand() { PaymentMethodEnum = paymentMethodEnum };
                RegisterPaymentMethod(paymentMethodCommand);
            }
        }

        /// ///
        private void ShowInstallmentPaymentDetail(IDto dto)
        {
            Console.WriteLine(dto.Display());
        }

        private void ShowInstallment(IDto dto)
        {
            Console.WriteLine(dto == null ? "Your order has successfully paid!" : dto.Display());
        }

        private void PaymentInstallment(IDto dto)
        {
            Console.WriteLine("Please Enter Payment code :");
            if (Console.ReadLine() == "1")
            {
                var installmentDto = (InstallmentDto)dto;
                ChangeTheStatusOfTheInstallment(new InstallmentCommand()
                { Installment = installmentDto.Installment, InstallmentPayment = installmentDto.InstallmentPayment });
            }
        }
        #endregion
    }
}
