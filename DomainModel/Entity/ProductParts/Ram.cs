using Infrostructure.Enums;

namespace DomainModel.Entity.ProductParts
{
    /// <summary>
    /// حافظه رم
    /// </summary>
    public class Ram : Device
    {
        public Ram(string type,string size,string brand, string details, string name, string color, Count processorCount, MemoryType computerMemoryType, Voltage voltage) : base(name, brand)
        {
            Type = type;
            Size = size;
            Color = color;
            ProcessorCount = processorCount;
            ComputerMemoryType = computerMemoryType;
            Voltage = voltage;
        }
        /// <summary>
        /// نوع
        /// </summary>
        public string Type { get; private set; }
        /// <summary>
        /// سایز
        /// </summary>
        public string Size { get; private set; }
        /// <summary>
        /// رنگ
        /// </summary>
        public string Color { get; private set; }
        /// <summary>
        /// تعداد پردازنده
        /// </summary>
        public Count ProcessorCount { get; private set; }
        /// <summary>
        /// نوع مموری
        /// </summary>
        public MemoryType ComputerMemoryType { get; private set; }
        /// <summary>
        /// ولتاژ مصرفی
        /// </summary>
        public Voltage Voltage { get; private set; }
        /// <summary>
        /// نوع قطعه
        /// </summary>
        public override DeviceType DeviceType => DeviceType.Ram;
    }
}
