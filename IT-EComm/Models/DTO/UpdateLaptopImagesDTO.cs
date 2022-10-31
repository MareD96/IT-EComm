using System.ComponentModel.DataAnnotations;

namespace IT_EComm.Models.DTO
{
    public class UpdateLaptopImagesDTO
    {
        public int Id { get; set; }
        [Required]
        public int LaptopId { get; set; }

        public string? ImageURL { get; set; }

        public string? Paths { get; set; }
    }
}
