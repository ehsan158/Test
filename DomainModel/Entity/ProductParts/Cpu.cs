using Infrostructure.Enums;
using Infrostructure.Exeption;

namespace DomainModel.Entity.ProductParts
{
    /// <summary>
    /// پردازنده
    /// </summary>
    public class Cpu : Device
    {
        public Cpu( string name, string brand, string details, string cpuManufacturer, Speed cpuSpeed, string cpuSocket, Count processorCount, Wattage wattage, string series, string model) : base(name, brand)
        {
            ValidateCpuManufacturer(cpuManufacturer);
            ValidateCpuSocket(cpuSocket);
            ValidateSeries(series);
            CpuManufacturer = cpuManufacturer;
            CpuSpeed = cpuSpeed;
            CpuSocket = cpuSocket;
            ProcessorCount = processorCount;
            Wattage = wattage;
            Series = series;
        }

        /// <summary>
        /// سازنده پردازنده
        /// </summary>
        public string CpuManufacturer { get; private set; }
        /// <summary>
        /// سرعت پردازنده
        /// </summary>
        public Speed CpuSpeed { get; private set; }
        /// <summary>
        /// سوکت پردازنده
        /// </summary>
        public string CpuSocket { get; private set; }
        /// <summary>
        /// تعداد پردازنده
        /// </summary>
        public Count ProcessorCount { get; private set; }
        /// <summary>
        /// وات مصرفی
        /// </summary>
        public Wattage Wattage { get; private set; }
        /// <summary>
        /// سری پردازنده
        /// </summary>
        public string Series { get; private set; }
        /// <summary>
        /// مدل پردازنده
        /// </summary>
        public string Model { get; private set; }
        /// <summary>
        /// نوع قطعه
        /// </summary>
        public override DeviceType DeviceType => DeviceType.Cpu;


        private void ValidateCpuManufacturer(string cpuManufacturer)
        {
            if (string.IsNullOrWhiteSpace(cpuManufacturer))
            {
                throw new InvalidCpuManufacturerException();
            }
        }
        private void ValidateCpuSocket(string cpuSocket)
        {
            if (string.IsNullOrWhiteSpace(cpuSocket))
            {
                throw new InvalidCpuSocketException();
            }
        }
        private void ValidateSeries(string series)
        {
            if (string.IsNullOrWhiteSpace(series))
            {
                throw new InvalidCpuSeriesException();
            }
        }
    }
}
