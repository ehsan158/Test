using Infrostructure.Enums;
using Infrostructure.Exeption;

namespace DomainModel.Entity.ProductParts
{
    public class HardDisk :Device
    {
       
        public HardDisk(string name, string brand, string type, string size, string details, string series, string hardwarePlatform, string operatingSystem, Weight weight, string color, string model) :base(name,brand)
        {
            ValidateHardDiskSeries(series);
            ValidateHardwarePlatform(hardwarePlatform);
            ValidateOperatingSystem(operatingSystem);
            Type = type;
            Size = size;
            Series = series;
            HardwarePlatform = hardwarePlatform;
            OperatingSystem = operatingSystem;
            Weight = weight;
            Color = color;
        }

        /// <summary>
        /// حافظه ذخیره سازی
        /// </summary>


        /// <summary>
        /// نوع حافظه
        /// </summary>
        public string Type { get; private set; }
        /// <summary>
        /// سایز
        /// </summary>
        public string Size { get; private set; }
        /// <summary>
        /// سری حافظه
        /// </summary>
        public string Series { get; private set; }
        /// <summary>
        /// پلتفرم حافظه
        /// </summary>
        public string HardwarePlatform { get; private set; }
        /// <summary>
        /// سیستم عامل
        /// </summary>
        public string OperatingSystem { get; private set; }
        /// <summary>
        /// وزن
        /// </summary>
        public Weight Weight { get; private set; }
        /// <summary>
        /// رنگ
        /// </summary>
        public string Color { get; private set; }
        /// <summary>
        /// نوع قطعه
        /// </summary>
        public override DeviceType DeviceType => DeviceType.HardDisk;

        private void ValidateHardDiskSeries(string series)
        {
            if (string.IsNullOrWhiteSpace(series))
            {
                throw new InvalidHardDiskSeriesException();
            }
        }
        private void ValidateHardwarePlatform(string hardwarePlatform)
        {
            if (string.IsNullOrWhiteSpace(hardwarePlatform))
            {
                throw new InvalidHardwarePlatformException();
            }
        }
        private void ValidateOperatingSystem(string operatingSystem)
        {
            if (string.IsNullOrWhiteSpace(operatingSystem))
            {
                throw new InvalidOperatingSystemException();
            }
        }
    }
}
