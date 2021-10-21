using Infrostructure.Enums;
using Infrostructure.Exeption;

namespace DomainModel.Entity.ProductParts
{
    public class Graphic : Device
    {
        /// <summary>
        /// کارت گرافیک
        /// </summary>
        public Graphic(string brand, string details, string name, string videoOutputInterface, string graphicsProcessorManufacturer, RamSize graphicsRamSize, MemoryType videoMemoryType, Frequency coreFrequency, StreamProcessorUnit streamProcessorUnit, string model) : base(name, brand)
        {
            ValidateGraphicsProcessorManufacturer(graphicsProcessorManufacturer);
            ValidateVideoOutputInterface(videoOutputInterface);
            VideoOutputInterface = videoOutputInterface;
            GraphicsProcessorManufacturer = graphicsProcessorManufacturer;
            GraphicsRamSize = graphicsRamSize;
            VideoMemoryType = videoMemoryType;
            CoreFrequency = coreFrequency;
            StreamProcessorUnit = streamProcessorUnit;
        }

        /// <summary>
        /// رابط خروجی ویدئو
        /// </summary>
        public string VideoOutputInterface { get;private set; }
        /// <summary>
        /// سازنده پردازنده کارت گرافیک
        /// </summary>
        public string GraphicsProcessorManufacturer { get;private set; }
        /// <summary>
        /// حجم حافظه گرافیکی
        /// </summary>
        public RamSize GraphicsRamSize { get;private set; }
        /// <summary>
        /// نوع حافظه گرافیکی
        /// </summary>
        public MemoryType VideoMemoryType { get;private set; }
        /// <summary>
        /// فرکانس هسته
        /// </summary>
        public Frequency CoreFrequency { get;private set; }
        /// <summary>
        /// واحد جریان پردازش
        /// </summary>
        public StreamProcessorUnit StreamProcessorUnit { get;private set; }
        /// <summary>
        /// نوع قطعه
        /// </summary>
        public override DeviceType DeviceType => DeviceType.Graphic;

        private void ValidateVideoOutputInterface(string videoOutputInterface)
        {
            if (string.IsNullOrWhiteSpace(videoOutputInterface))
            {
                throw new InvalidVideoOutputInterfaceException();
            }
        }
        private void ValidateGraphicsProcessorManufacturer(string graphicsProcessorManufacturer)
        {
            if (string.IsNullOrWhiteSpace(graphicsProcessorManufacturer))
            {
                throw new InvalidGraphicsProcessorManufacturerException();
            }
        }
    }
}