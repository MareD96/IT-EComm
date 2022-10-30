using System.ComponentModel.DataAnnotations;

namespace IT_EComm.Models.DTO
{
    public class UpdateLaptopDTO
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
        public string DDR { get; set; }

        //Graphic Card
        [Required]
        public string GraphicCardBrand { get; set; }
        [Required]
        public string GraphicCardModel { get; set; }
        public int? GraphicCardMemory { get; set; }
        [Required]
        public string Color { get; set; }


        //CPU
        [Required]
        public string ProcessorBrand { get; set; }
        [Required]
        public string ProcessorModel { get; set; }
        public int? ProcessorNoCores { get; set; }
        public double? CPUSpeed { get; set; }


        //Storage
        [Required]
        public string Storage { get; set; }
        [Required]
        public int StorageSize { get; set; }

        //Os 
        [Required]
        public string OS { get; set; }

        //

        //Display
        public string? Resolution { get; set; }
        public double? Inchs { get; set; }

        //other thins will be showin in description string
        public string? Description { get; set; }
    }
}
