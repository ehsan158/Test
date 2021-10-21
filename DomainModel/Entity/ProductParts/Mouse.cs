using Infrostructure.Enums;
using Infrostructure.Exeption;

namespace DomainModel.Entity.ProductParts
{
    public class Mouse : Device
    {
        /// <summary>
        /// ماوس
        /// </summary>
        public Mouse(string brand, string details, string name, string series, string hardwarePlatform, string operatingSystem, Weight weight, string color, HandOrientation handOrientation, MovementDetectionTechnology movementDetectionTechnology, Connectivity connectivity, string model) : base(name,brand)
        {
            ValidateSeries(series);
            ValidateHardwarePlatform(hardwarePlatform);
            ValidateOperatingSystem(operatingSystem);
            Series = series;
            HardwarePlatform = hardwarePlatform;
            OperatingSystem = operatingSystem;
            Weight = weight;
            Color = color;
            HandOrientation = handOrientation;
            MovementDetectionTechnology = movementDetectionTechnology;
            Connectivity = connectivity;
        }

        /// <summary>
        /// سری موس
        /// </summary>
        public string Series { get; private set; }
        /// <summary>
        /// پلتفرم
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
        /// تناسب با دست فرد
        /// </summary>
        public HandOrientation HandOrientation { get;private set; }
        /// <summary>
        /// تکنولوژی تشخیص حرکت
        /// </summary>
        public MovementDetectionTechnology MovementDetectionTechnology { get;private set; }
        /// <summary>
        /// نوع رابط
        /// </summary>
        public Connectivity Connectivity { get;private set; }
        /// <summary>
        /// نوع قطعه
        /// </summary>
        public override DeviceType DeviceType => DeviceType.Mouse;

        private void ValidateSeries(string series)
        {
            if (string.IsNullOrWhiteSpace(series))
            {
                throw new InvalidMouseSeriesException();
            }
        }
        private void ValidateHardwarePlatform(string hardwarePlatform)
        {
            if (string.IsNullOrWhiteSpace(hardwarePlatform))
            {
                throw new InvalidMouseHardwarePlatformException();
            }
        }
        private void ValidateOperatingSystem(string operatingSystem)
        {
            if (string.IsNullOrWhiteSpace(operatingSystem))
            {
                throw new InvalidMouseOperatingSystemException();
            }
        }
    }
}