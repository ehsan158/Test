using System;
using Infrostructure.Enums;

namespace DomainModel.Entity.ProductParts
{
    public abstract class Device
    {

        /// <summary>
        /// کلاس مادر قطعات
        /// </summary>


        public Guid Id{ get; private set; }
        /// <summary>
        /// نام
        /// </summary>
        public string Name{ get; private set; }
        /// <summary>
        /// برند
        /// </summary>
        public string Brand{ get; private set; }
        /// <summary>
        /// نوع قطعه
        /// </summary>
        public abstract DeviceType DeviceType { get; }

        public Device(string name, string brand)
        {
            Name = name;
            Brand = brand;
        }
    }
}
