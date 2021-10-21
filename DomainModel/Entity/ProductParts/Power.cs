using Infrostructure.Enums;
using Infrostructure.Exeption;

namespace DomainModel.Entity.ProductParts
{
    public class Power : Device
    {
        /// <summary>
        /// پاور
        /// </summary>
        public Power(string brand, string details, string name, Wattage outputWattage, CoolingMethod coolingMethod, string powerSupplyDesign, Weight weight, Voltage maximumInputVoltage, Count fansIncludedCount, Count fansSupportCount, string model) : base(name, brand)
        {
            ValidatePowerSupplyDesign(powerSupplyDesign);
            OutputWattage = outputWattage;
            CoolingMethod = coolingMethod;
            PowerSupplyDesign = powerSupplyDesign;
            Weight = weight;
            MaximumInputVoltage = maximumInputVoltage;
            FansIncludedCount = fansIncludedCount;
            FansSupportCount = fansSupportCount;
        }

        /// <summary>
        /// وات خروجی
        /// </summary>
        public Wattage OutputWattage { get;private set; }
        /// <summary>
        /// نوع خنک کننده
        /// </summary>
        public CoolingMethod CoolingMethod { get;private set; }
        /// <summary>
        /// طراحی تامین نیرو
        /// </summary>
        public string PowerSupplyDesign { get;private set; }
        /// <summary>
        /// وزن
        /// </summary>
        public Weight Weight { get;private set; }
        /// <summary>
        /// حداکثر ولتاژ ورودی
        /// </summary>
        public Voltage MaximumInputVoltage { get;private set; }
        /// <summary>
        /// تعداد فن ها روی خود دستگاه
        /// </summary>
        public Count FansIncludedCount { get;private set; }
        /// <summary>
        /// تعداد فن های پشتیبانی شده
        /// </summary>
        public Count FansSupportCount { get;private set; }
        /// <summary>
        /// نوع قطعه
        /// </summary>
        public override DeviceType DeviceType => DeviceType.Power;
        private void ValidatePowerSupplyDesign(string powerSupplyDesign)
        {
            if (string.IsNullOrWhiteSpace(powerSupplyDesign))
            {
                throw new InvalidPowerSupplyDesignException();
            }
        }
    }
}