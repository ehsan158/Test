using System;
using System.Collections.Generic;
using DomainModel.Entity.product;
using Infrostructure.Enums;

namespace Repository.Repository.Read.Interfaces
{
    public interface IProductRepositoryRead
    {
        public IEnumerable<Product> GetAllProducts();
        public Product GetProductByProductNumber(int productNumber);
        public Product GetProductById(Guid id);
        public IEnumerable<Product> GetProductsByDeviceType(DeviceType deviceType);
    }
}
