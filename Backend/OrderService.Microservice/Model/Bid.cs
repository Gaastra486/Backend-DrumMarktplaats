using System.ComponentModel.DataAnnotations;

namespace OrderService.Microservice.Model
{
    public class Bid
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int userId { get; set; }

        [Required]
        public int productId { get; set; }

        [Required]
        public double bidAmount { get; set; }

        [Required]
        public DateTime created { get; set; }
    }
}
