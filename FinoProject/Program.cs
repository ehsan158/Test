using System;
using ApplicationServices.Services.Implementations;
using DomainModel.Entity.DomainServices;
using FinoProject.Controller;
using Infrostructure.Enums;
using Infrostructure.ExtensionMethods;
using Repository.Repository.Read.Implementations;
using Repository.Repository.Write.Implementations;

namespace FinoProject
{
    class Program
    {
        private static OrderController _orderController;
        private static ProductController _productController;
        private static PaymentController _paymentController;
        private static AccountController _accountController;
        static void Main(string[] args)
        {
            var orderRepositoryRead = new OrderRepositoryRead();
            var userRepositoryRead = new UserRepositoryRead();
            var productRepositoryRead = new ProductRepositoryRead();
            var orderRepositoryWrite = new OrderRepositoryWrite();
            var paymentServiceDom = new PaymentServiceDom();

            var paymentService = new PaymentServices(orderRepositoryRead, userRepositoryRead, paymentServiceDom);
            var accountService = new AccountService(userRepositoryRead);
            var productService = new ProductsServices(productRepositoryRead, orderRepositoryRead, userRepositoryRead, orderRepositoryWrite);
            var orderService = new OrderServices(userRepositoryRead, orderRepositoryRead);

            _orderController = new OrderController(orderService, paymentService);
            _productController = new ProductController(productService);
            _paymentController = new PaymentController(orderService, paymentService);
            _accountController = new AccountController(accountService);

            _accountController.Login();
            _productController.GetAllProductLoop();
            ShowPanel();
        }

        private static void Run(int input)
        {
            switch (input)
            {
                case 1:
                    _productController.GetAllProductLoop();
                    break;
                case 2:
                    _productController.GetRemove();
                    break;
                case 3:
                    _productController.GetDetailProductsSelected();
                    break;
                case 4:
                    _paymentController.GetPaymentMethod();
                    break;
                case 5:
                    _paymentController.GetInstallmentPaymentDetail();
                    break;
                case 6:
                    _orderController.GetFinalizeTheOrder();
                    break;
                case 7:
                    _paymentController.PaymentOfInstallments();
                    break;
                case 8:
                    _orderController.CancleOrder();
                    break;
            }
        }
        private static void ShowPanel()
        {
            while (true)
            {
                if (_orderController.CheckPaidOrder())
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\nOrder state is : " + _orderController.GetDescriptionState());
                    Console.ResetColor();
                    break;
                }
                Panel();
            }
        }
        private static void Panel()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\nOrder state is : " + _orderController.GetDescriptionState());
            Console.ResetColor();

            Console.WriteLine("1.Choose new product\n2.Remove product\n3.Prices of selected products\n4.Choose payment method\n5.See Payment Details\n6.Final purchase order\n7.Payment of installments\n8.Cancle order");
            Run(Console.ReadLine().HandleInput());
        }
    }
}
