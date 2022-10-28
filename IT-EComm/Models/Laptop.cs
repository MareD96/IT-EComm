namespace IT_EComm.Models
{
    public class Laptop
    {

        //General information
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }

        //Ram memory
        public int RAMMemory { get; set; }

        //Graphic Card
        public string GraphicCardBrand { get; set; }
        public string GraphicCardModel { get; set; }
        public int GraphicCardMemory { get; set; }

        //CPU
        public string ProcessorBrand { get; set; }
        public string ProcessorModel { get; set; }
        public int ProcessorNoCores { get; set; }
        public double CPUSpeed { get; set; }


        //Storage


        //Display and other info

    }
}
