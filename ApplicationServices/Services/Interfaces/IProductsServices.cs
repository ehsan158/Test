using System;
using System.Collections.Generic;
using ApplicationServices.Command;
using ApplicationServices.DTO;
using Infrostructure.Enums;

namespace ApplicationServices.Services.Interfaces
{
    public interface IProductsServices
    {
        public List<ProductDto> GetProducts(DeviceType deviceType);
        public void RemoveProduct(Guid userId, ProductCommand productCommand);
        public ProductsDetailDto GetSelectedProductsDetails(Guid userId);
        public void RegisterProduct(Guid userId, List<ProductCommand> productCommands);
        public List<ProductDto> GetSelectedProducts(Guid userId);
        public string ValidateForAddOrRemoveProduct(Guid userId);

    }
}
