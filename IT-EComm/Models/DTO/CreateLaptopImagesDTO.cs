using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IT_EComm.Models.DTO
{
    public class CreateLaptopImagesDTO
    {
        [Required]
        public int LaptopId { get; set; }

        public string? ImageURL { get; set; }

        public string? Paths { get; set; }
    }
}
