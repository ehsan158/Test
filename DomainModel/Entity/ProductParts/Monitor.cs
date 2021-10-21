using Infrostructure.Enums;
using Infrostructure.Exeption;

namespace DomainModel.Entity.ProductParts
{
    /// <summary>
    /// نمایشگر
    /// </summary>
    public class Monitor : Device
    {
       
        public Monitor(string brand, string details, string name, string aspectRatio, Size screenSize, DisplayType displayType, Weight weight, string color, MountingType mountingType, Frequency refreshRate, Voltage voltage, string model) : base(name, brand)
        {
            ValidateAspectRatio(aspectRatio);
            AspectRatio = aspectRatio;
            ScreenSize = screenSize;
            DisplayType = displayType;
            Weight = weight;
            Color = color;
            MountingType = mountingType;
            RefreshRate = refreshRate;
            Voltage = voltage;
        }


        /// <summary>
        /// نسبت اندازه صفحه
        /// </summary>
        public string AspectRatio { get;private set; }
        /// <summary>
        /// اندازه صفحه
        /// </summary>
        public Size ScreenSize { get; private set; }
        /// <summary>
        /// نوع صفحه نمایش
        /// </summary>
        public DisplayType DisplayType { get;private set; }
        /// <summary>
        /// وزن
        /// </summary>
        public Weight Weight { get; private set; }
        /// <summary>
        /// رنگ
        /// </summary>
        public string Color { get; private set; }
        /// <summary>
        /// شیوه نصب (قرارگیری) دستگاه
        /// </summary>
        public MountingType MountingType { get;private set; }
        /// <summary>
        /// نرخ تازه سازی
        /// </summary>
        public Frequency RefreshRate { get;private set; }
        /// <summary>
        /// ولتاژ مصرفی
        /// </summary>
        public Voltage Voltage { get; private set; }        
        /// <summary>
        /// نوع قطعه
        /// </summary>
        public override DeviceType DeviceType => DeviceType.Monitor;

        private void ValidateAspectRatio(string aspectRatio)
        {
            if (string.IsNullOrWhiteSpace(aspectRatio))
            {
                throw new InvalidAspectRatioException();
            }
        }
    }
}