using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT_EComm.Models
{
    public class LaptopImages
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Laptop")]
        public int LaptopId { get; set; }
        public Laptop Laptop { get; set; }

        public string? ImageURL { get; set; }

        public string? Paths { get; set; }

    }
}
