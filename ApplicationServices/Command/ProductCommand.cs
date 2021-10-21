using System;
using ApplicationServices.Exception;
using Infrostructure.Enums;

namespace ApplicationServices.Command
{
    public class ProductCommand : CommandBase
    {
        public int ProductNumber { get; set; }
        public DeviceType DeviceType { get; set; }

        public override void Validate()
        {
            switch (DeviceType)
            {
                case DeviceType.Cpu:
                    if (ProductNumber is < 1 or > 3)
                        throw new InvalidProductNumberExeption();
                    break;

                case DeviceType.Ram:
                    if (ProductNumber is < 4 or > 6)
                        throw new InvalidProductNumberExeption();
                    break;

                case DeviceType.MotherBoard:
                    if (ProductNumber is < 7 or > 9)
                        throw new InvalidProductNumberExeption();
                    break;

                case DeviceType.HardDisk:
                    if (ProductNumber is < 10 or > 12)
                        throw new InvalidProductNumberExeption();
                    break;
            }
        }
    }
}
