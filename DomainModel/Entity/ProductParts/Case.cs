using Infrostructure.Enums;

namespace DomainModel.Entity.ProductParts
{
    public class Case : Device
    {
        /// <summary>
        /// محفظه کیس
        /// </summary>
        public Case(string brand, string details, string name, string model, Weight weight, string color, Count numberOfUsb3Ports, Count numberOfUsb2Ports, CoolingMethod coolingMethod, Size fanSize, Count fanCount) : base(name, brand)
        {
            Weight = weight;
            Color = color;
            NumberOfUsb3Ports = numberOfUsb3Ports;
            NumberOfUsb2Ports = numberOfUsb2Ports;
            CoolingMethod = coolingMethod;
            FanSize = fanSize;
            FanCount = fanCount;
            FanCount = fanCount;
        }
        /// <summary>
        /// وزن
        /// </summary>
        public Weight Weight { get; private set; }
        /// <summary>
        /// رنگ
        /// </summary>
        public string Color { get;private set; }
        /// <summary>
        /// تعداد پورت های یو اس بی 3
        /// </summary>
        public Count NumberOfUsb3Ports { get;private set; }
        /// <summary>
        /// تعداد پورت های یو اس بی 2
        /// </summary>
        public Count NumberOfUsb2Ports { get; private set; }
        /// <summary>
        /// نوع خنک کننده
        /// </summary>
        public CoolingMethod CoolingMethod { get;private set; }
        /// <summary>
        /// اندازه فن خنک کننده
        /// </summary>
        public Size FanSize { get;private set; }
        /// <summary>
        /// تعداد فن های حنک کننده
        /// </summary>
        public Count FanCount { get;private set; }
        /// <summary>
        /// نوع قطعه
        /// </summary>
        public override DeviceType DeviceType => DeviceType.Case;
    }
}