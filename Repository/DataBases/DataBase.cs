using System.Collections.Generic;
using DomainModel.Entity.AmountClasses;
using DomainModel.Entity.Cart;
using DomainModel.Entity.product;
using DomainModel.Entity.ProductParts;
using DomainModel.Entity.user;

namespace Repository.DataBases
{
    public class DataBase
    {
        private List<Cpu> Cpus { get; set; }
        private List<HardDisk> HardDisks { get; set; }
        private List<MotherBoard> MotherBoards { get; set; }
        private List<Ram> Rams { get; set; }
        public List<User> Users { get; set; }
        public List<Product> Products { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();

        private static DataBase _instance;
        public static DataBase GetInstance()
        {
            if(_instance == null)
            {
                _instance = new DataBase();
                _instance.SetProducts();
            }
            return _instance;
        }

        private DataBase()
        {
            Cpus = new List<Cpu>()
            {
                new Cpu("Intel: Coffee Lake series / model Core i5-9400f","Intel","Core i5-9400f","qwe",new Speed(12),"1qw",new Count(12),new Wattage(12),"Aseries","pmodel"),
                new Cpu("Intel: Comet Lake series / model Core i7-10700k", "Intel", "Core i7-10700k","qwe",new Speed(12),"1qw",new Count(12),new Wattage(12),"Aseries","pmodel"),
                new Cpu("Intel: Comet Lake series / model Core i9-10900", "Intel", "Core i9-10900","qwe",new Speed(12),"1qw",new Count(12),new Wattage(12),"Aseries","pmodel")
            };
            HardDisks = new List<HardDisk>()
            {
                new HardDisk("Adata SU650 SSD - 120GB","Adata","SSD","120 GB","qtype","wsocket","qtype","wsocket",new Weight(120),"red","amodel"),
                new HardDisk("Western Digital BLUE WDS500G1B0A SSD Drive - 500GB", "Western","SSD","500 GB","qtype","wsocket","qtype","wsocket",new Weight(120),"red","amodel"),
                new HardDisk("Western Digital Purple WD10PURZ Internal Hard Disk 1TB","Western","Internal","1 TB","qtype","wsocket","qtype","wsocket",new Weight(120),"red","amodel")
            };
            MotherBoards = new List<MotherBoard>()
            {
                new MotherBoard("Asus PRIME H310M-K R2.0 Motherboard","Asus", "Intel LGA 1151","qtype","wsocket",new Count(1),new RamSize(12),"hightech",new Speed(100),"amodel"),
                new MotherBoard("GIGABYTE H410M S2H rev. 1.x Motherboard","GIGABYTE", "Intel LGA 1200","qtype","wsocket",new Count(1),new RamSize(12),"hightech",new Speed(100),"amodel"),
                new MotherBoard("ASUS ROG RAMPAGE VI EXTREME Motherboard","Asus","Intel LGA 2066","qtype","wsocket",new Count(1),new RamSize(12),"hightech",new Speed(100),"amodel")
            };
            Rams = new List<Ram>()
            {
                new Ram("DDR4","16 GB","Kingston","good","Kingston HyperX Fury 16GB DDR4 2666MHz CL15 Quad Channel RAM","red",new Count(12),Infrostructure.Enums.MemoryType.DDR1,new Voltage(20)),
                new Ram("DDR4","8 GB","Kingston","good","Kingston HyperX Fury 8GB DDR4 2400MHz CL15 Single Channel RAM","red",new Count(12),Infrostructure.Enums.MemoryType.DDR1,new Voltage(20)),
                new Ram("DDR3", "4 GB","Samsung","good","Samsung 12800 1600MHz Desktop DDR3 RAM 4GB","red",new Count(12),Infrostructure.Enums.MemoryType.DDR1,new Voltage(20))
            };
            Users = new List<User>()
            {
                new User("ehsan","ehsan","6.sep","ehsan.ghaderian3@gmail.com","Tehran,valiasr"),
                new User("afshin","afshin","2.dec","afshin@gmail.com","Yazd,safaiee")
            };
        }
        public void SetProducts()
        {
           Products = new List<Product>()
            {
                new Product(1,Cpus[0],new Amount(100000),"C1"),
                new Product(2,Cpus[1],new Amount(200000),"C2"),
                new Product(3,Cpus[2],new Amount(300000),"C3"),
                new Product(4,Rams[0],new Amount(100000),"R1"),
                new Product(5,Rams[1],new Amount(200000),"R2"),
                new Product(6,Rams[2],new Amount(300000),"R3"),
                new Product(7,MotherBoards[0],new Amount(100000),"MB3"),
                new Product(8,MotherBoards[1],new Amount(200000),"MB3"),
                new Product(9,MotherBoards[2],new Amount(300000),"MB3"),
                new Product(10,HardDisks[0],new Amount(100000),"HD1"),
                new Product(11,HardDisks[1],new Amount(200000),"HD2"),
                new Product(12,HardDisks[2],new Amount(300000),"HD3"),
            };
        }
    }
}
