using Infrostructure.Enums;
using Infrostructure.Exeption;

namespace DomainModel.Entity.ProductParts
{
    /// <summary>
    /// بورد اصلی
    /// </summary>
    public class MotherBoard :Device
    {
        public MotherBoard(string name,string brand, string details, string chipsetType, string cpuSocket, Count memorySlotsAvailable, RamSize ramMemoryMaximumSize, string ramMemoryTechnology, Speed memorySpeed, string model) : base(name, brand)
        {
            ValidateCpuSocket(cpuSocket);
            ValidateChipsetType(chipsetType);
            ValidateRamMemoryTechnology(ramMemoryTechnology);
            ChipsetType = chipsetType;
            CpuSocket = cpuSocket;
            MemorySlotsAvailable = memorySlotsAvailable;
            RamMemoryMaximumSize = ramMemoryMaximumSize;
            RamMemoryTechnology = ramMemoryTechnology;
            MemorySpeed = memorySpeed;
        }
        /// <summary>
        /// نوع چیپست پردازنده
        /// </summary>
        public string ChipsetType { get; private set; }
        /// <summary>
        /// سوکت پردازنده
        /// </summary>
        public string CpuSocket { get; private set; }
        /// <summary>
        /// تعداد درگاه های مموری
        /// </summary>
        public Count MemorySlotsAvailable { get; private set; }
        /// <summary>
        /// حداکثر حجم حافظه مموری
        /// </summary>
        public RamSize RamMemoryMaximumSize { get; private set; }
        /// <summary>
        /// تکنولوژی رم مموری
        /// </summary>
        public string RamMemoryTechnology { get; private set; }
        /// <summary>
        /// سرعت مموری
        /// </summary>
        public Speed MemorySpeed { get; private set; }
        /// <summary>
        /// نوع قطعه
        /// </summary>
        public override DeviceType DeviceType => DeviceType.MotherBoard;

        private void ValidateChipsetType(string chipsetType)
        {
            if (string.IsNullOrWhiteSpace(chipsetType))
            {
                throw new InvalidChipsetTypeException();
            }
        }
        private void ValidateCpuSocket(string cpuSocket)
        {
            if (string.IsNullOrWhiteSpace(cpuSocket))
            {
                throw new InvalidCpuSocketException();
            }
        }
        private void ValidateRamMemoryTechnology(string ramMemoryTechnology)
        {
            if (string.IsNullOrWhiteSpace(ramMemoryTechnology))
            {
                throw new InvalidRamMemoryTechnologyException();
            }
        }
    }
}
