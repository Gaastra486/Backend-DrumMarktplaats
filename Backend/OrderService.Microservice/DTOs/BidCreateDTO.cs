using System.ComponentModel.DataAnnotations;

namespace OrderService.Microservice.DTOs
{
    public class BidCreateDTO
    {
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
