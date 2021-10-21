using System;
using DomainModel.Entity.AmountClasses;
using DomainModel.Entity.ProductParts;
using Infrostructure.Exeption;

namespace DomainModel.Entity.product
{
    public class Product
    {
        public Product(int productNumber, Device device, Amount price, string name)
        {
            Id = Guid.NewGuid();
            ValidateName(name);
            ValidateDevice(device);
            ValidatePrice(price);
            ProductNumber = productNumber;
            Name = name;
            Price = price;
            Device = device;
        }

        /// <summary>
        /// شناسه
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// شماره محصول
        /// </summary>
        public int ProductNumber { get; private set; }

        /// <summary>
        ///نام
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// قیمت
        /// </summary>
        public Amount Price { get; private set; }

        /// <summary>
        /// قطعه
        /// </summary>
        public Device Device { get; private set; }

        //Validations
        private void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ProductNameEmptyException();
            }
        }
        private void ValidateDevice(Device device)
        {
            if (device == null)
            {
                throw new DeviceNullReferenceException();
            }
        }
        private void ValidatePrice(Amount price)
        {
            if (price == null)
            {
                throw new PriceNullReferenceException();
            }
        }
    }
}
