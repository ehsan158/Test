using System;
using System.Collections.Generic;
using System.Linq;
using DomainModel.Entity.product;
using Infrostructure.Enums;
using Repository.DataBases;
using Repository.Repository.Read.Interfaces;

namespace Repository.Repository.Read.Implementations
{
    public class ProductRepositoryRead : IProductRepositoryRead
    {
        DataBase _dataBase;
        public ProductRepositoryRead()
        {
            _dataBase = DataBase.GetInstance();
        }

        public Product GetProductByProductNumber(int productNumber)
        {
            return _dataBase.Products.FirstOrDefault(c => c.ProductNumber == productNumber);
        }

        public IEnumerable<Product> GetAllProducts()
        {
           return _dataBase.Products.ToList();
        }

        public IEnumerable<Product> GetProductsByDeviceType(DeviceType deviceType)
        {
            return _dataBase.Products.Where(c => c.Device.DeviceType == deviceType).ToList();
        }

        public Product GetProductById(Guid id)
         {
            return _dataBase.Products.SingleOrDefault(c=> c.Id == id);
        }
    }
}
