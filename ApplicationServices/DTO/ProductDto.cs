using DomainModel.Entity.ProductParts;

namespace ApplicationServices.DTO
{
    public class ProductDto:IDto
    {
        public int ProductNumber { get; set; }
        public Device Device { get; set; }
        public decimal Price { get; set; }

        public string Display()
        {
            return $"{this.ProductNumber}. Name : {Device.Name} / Brand : {Device.Brand} / Price : {Price}";
        }
    }
}
