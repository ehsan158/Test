using Infrostructure.Enums;
using Infrostructure.Exeption;

namespace Infrostructure.ExtensionMethods
{
    public static class GetProductsByDeviceType
    {
        public static DeviceType GetDeviceType(this int value)
        {
            switch (value)
            {
                case 1:
                    return DeviceType.Cpu;

                case 2:
                    return DeviceType.Ram;

                case 3:
                    return DeviceType.MotherBoard;

                case 4:
                    return DeviceType.HardDisk;
                default:
                    throw new InvalidDeviceTypeExeption();
            }
        }
    }
}
