using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationServices.Command;
using ApplicationServices.DTO;
using ApplicationServices.Services.Interfaces;
using DomainModel.Entity.Cart;
using DomainModel.Entity.product;
using DomainModel.StatePattern.OrderState;
using Infrostructure.Enums;
using Repository.Repository.Read.Interfaces;
using Repository.Repository.Write.Interfaces;

namespace ApplicationServices.Services.Implementations
{
    public class ProductsServices : IProductsServices
    {
        #region Constructor
        readonly IProductRepositoryRead _productRepositoryRead;
        readonly IOrderRepositoryRead _orderRepositoryRead;
        readonly IUserRepositoryRead _userRepositoryRead;
        private IOrderRepositoryWrite _orderRepositoryWrite;

        public ProductsServices(IProductRepositoryRead productRepositoryRead, IOrderRepositoryRead orderRepositoryRead, IUserRepositoryRead userRepositoryRead, IOrderRepositoryWrite orderRepositoryWrite)
        {
            _productRepositoryRead = productRepositoryRead;
            _orderRepositoryRead = orderRepositoryRead;
            _userRepositoryRead = userRepositoryRead;
            _orderRepositoryWrite = orderRepositoryWrite;
        }
        #endregion

        #region Register Products

        public string ValidateForAddOrRemoveProduct(Guid userId)
        {
            var user = _userRepositoryRead.GetUserById(userId);
            var order = _orderRepositoryRead.GetOrderById(user.OrdersId.LastOrDefault());

            if (order?.CurrentState.OrderStateEnum is OrderStateEnum.CheckOut or OrderStateEnum.Bought)
                return "You can not add or remove any product!";

            return null;
        }
        public List<ProductDto> GetProducts(DeviceType deviceType)
        {
            var products = _productRepositoryRead.GetProductsByDeviceType(deviceType);
            var productsDto = products.Select(product => new ProductDto() {ProductNumber = product.ProductNumber, Device = product.Device, Price = product.Price.Value}).ToList();
            return productsDto;
        }

        public void RegisterProduct(Guid userId, List<ProductCommand> productCommands)
        {
            Order order = null;
            var user = _userRepositoryRead.GetUserById(userId);
            var ordersId = user.OrdersId.ToList();

            if (ordersId.Any())
                order = _orderRepositoryRead.GetOrderById(ordersId.LastOrDefault());

            var products = productCommands.Select(command => _productRepositoryRead.GetProductByProductNumber(command.ProductNumber));

            var productsForAdd = products.Select(c => new Product(c.ProductNumber, c.Device, c.Price, c.Name)).ToList();

            if (order == null)
            {
                order = new Order(productsForAdd);
                _orderRepositoryWrite.AddOrderInDb(order);
                user.AddOrder(order.Id);
            }
            else
            {
                order.AddProducts(productsForAdd);
            }
        }
        #endregion

        #region  Remove Products

        public void RemoveProduct(Guid userId, ProductCommand productCommand)
        {
            var user = _userRepositoryRead.GetUserById(userId);
            var order = _orderRepositoryRead.GetOrderById(user.OrdersId.LastOrDefault());

            var product = order.Products.FirstOrDefault(c => c.ProductNumber == productCommand.ProductNumber);

            order.RemoveProduct(product);
        }

        #endregion

        #region Get Selected Products
        public List<ProductDto> GetSelectedProducts(Guid userId)
        {
            var user = _userRepositoryRead.GetUserById(userId);
            var order = _orderRepositoryRead.GetOrderById(user.OrdersId.LastOrDefault());

            return order.Products.Select(product => new ProductDto()
            { ProductNumber = product.ProductNumber, Device = product.Device, Price = product.Price.Value }).ToList();
        }
        #endregion

        #region Get Selected Products Details
        public ProductsDetailDto GetSelectedProductsDetails(Guid userId)
        {
            var user = _userRepositoryRead.GetUserById(userId);
            var order = _orderRepositoryRead.GetOrderById(user.OrdersId.LastOrDefault());
            var products = order.Products.ToList();

            return new ProductsDetailDto()
            {
                Products = products,
                TotalPrice = products.Sum(c => c.Price.Value)
            };
        }
        #endregion
    }
}
