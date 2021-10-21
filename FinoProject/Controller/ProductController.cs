using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationServices.Command;
using ApplicationServices.DTO;
using ApplicationServices.Services.Interfaces;
using Infrostructure;
using Infrostructure.Enums;
using Infrostructure.ExtensionMethods;

namespace FinoProject.Controller
{
    public class ProductController
    {
        #region Constructor
        private IProductsServices _productsServices;

        public ProductController(IProductsServices productsServices)
        {
            _productsServices = productsServices;
        }
        #endregion

        #region AddProduct
        //Get
        private bool GetAllProduct()
        {
            var message = _productsServices.ValidateForAddOrRemoveProduct(AuthenticationInformation.UserId);

            if (message != null)
            {
                PrintMessage(message);
                return false;
            }

            else
            {
                var deviceType = GetProductsType();
                var result = _productsServices.GetProducts(deviceType);
                ShowProductsForAdd(new List<IDto>(result));
                GetProduct(deviceType);
                return true;
            }

        }
        //Post
        private void RegisterProduct(List<ProductCommand> commands)
        {
            commands.ForEach(c => c.Validate());

            _productsServices.RegisterProduct(AuthenticationInformation.UserId, commands);
        }

        public void GetAllProductLoop()
        {
            while (true)
            {
                if (!GetAllProduct())
                    break;

                Console.WriteLine("Do you want to another product?(y/n)");
                if (Console.ReadLine() == "n") break;
            }
        }
        #endregion

        #region RemoveProduct
        //Get
        public void GetRemove()
        {
            var userId = AuthenticationInformation.UserId;

            var message = _productsServices.ValidateForAddOrRemoveProduct(userId);
            if (message != null)
                PrintMessage(message);
            else
            {
                var result = _productsServices.GetSelectedProducts(userId);
                ShowProductsForRemove(new List<IDto>(result));
                GetProductForRemove();
            }

        }
        //Post
        private void RemoveProduct(ProductCommand productCommand)
        {
            productCommand.Validate();

            _productsServices.RemoveProduct(AuthenticationInformation.UserId, productCommand);
        }
        #endregion

        #region Detail Products
        public void GetDetailProductsSelected()
        {
            var result = _productsServices.GetSelectedProductsDetails(AuthenticationInformation.UserId);
            ShowProductsDetails(result);
        }
        #endregion

        #region View
        private DeviceType GetProductsType()
        {
            Console.WriteLine("\nChoose Product Type\n1.Cpu\n2.Ram\n3.MotherBoard\n4.HardDisk");
            return Console.ReadLine().HandleInput().GetDeviceType();
        }
        private void ShowProductsForAdd(List<IDto> productsDto)
        {
            productsDto.ForEach(dto => Console.WriteLine(dto.Display()));
        }

        private void GetProduct(DeviceType deviceType)
        {
            Console.WriteLine("Choose a product : ");
            var productsCommand = new List<ProductCommand>()
            {
                new ProductCommand() {ProductNumber = Console.ReadLine().HandleInput(),DeviceType = deviceType}
            };
            RegisterProduct(productsCommand);
        }

        private void ShowProductsForRemove(List<IDto> productsDto)
        {
            productsDto.ForEach(dto => Console.WriteLine(dto.Display()));
        }

        private void GetProductForRemove()
        {
            Console.WriteLine("Choose a product : ");
            var productCommand = new ProductCommand()
            {
                ProductNumber = Console.ReadLine().HandleInput()
            };
            RemoveProduct(productCommand);
        }

        private void ShowProductsDetails(IDto productsDetailDto)
        {
            Console.WriteLine(productsDetailDto.Display());
        }

        private void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }
        #endregion
    }
}
