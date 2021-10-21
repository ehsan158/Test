using System.Collections.Generic;
using DomainModel.Entity.product;

namespace ApplicationServices.DTO
{
    public class ProductsDetailDto : IDto
    {
        public IEnumerable<Product> Products { get; set; }
        public decimal TotalPrice { get; set; }
        public string Display()
        {
            string text = "";
            foreach (var product in Products)
            {
                text += $"\n {product.ProductNumber}. Name : {product.Device.Name} / Price : {product.Price.Value}";
            }
            text += $"\n TotalPrice : {TotalPrice}";
            return text;
        }
    }
}
