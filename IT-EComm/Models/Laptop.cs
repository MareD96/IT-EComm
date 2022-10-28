using System.ComponentModel.DataAnnotations;
using static IT_EComm.Helpers.Utility;

namespace IT_EComm.Models
{
    public class Laptop
    {

        //General information
        [Key]
        public int Id { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public double Price { get; set; }

        //Ram memory
        [Required]
        public int RAMMemory { get; set; }

        //Graphic Card
        [Required]
        public Brands GraphicCardBrand { get; set; }
        [Required]
        public string GraphicCardModel { get; set; }
        [Required]
        public int GraphicCardMemory { get; set; }
        [Required]
        public string Color { get; set; }


        //CPU
        [Required]
        public Brands ProcessorBrand { get; set; }
        [Required]
        public string ProcessorModel { get; set; }
        [Required]
        public int ProcessorNoCores { get; set; }
        [Required]
        public double CPUSpeed { get; set; }
        [Required]


        //Storage

        public Storage Storage { get; set; }

        public int StorageSize { get; set; }

        //Os 
        public OS OS { get; set; }

        //

        //Display
        public string Resolution { get; set; }
        public double Inchs { get; set; }
        


        //Communication
        public string WebCam { get; set; }
        public string WiFi { get; set; }
        public string LAN { get; set; }
        public int BluetoothNo { get; set; }
        public int UsbCNo { get; set; }

        //Image
        public string ImageURl { get; set; }


    }
}
