using System.ComponentModel.DataAnnotations;

namespace OrderService.Microservice.DTOs
{
    public class BidReadDTO
    {
        [Required]
        public int Id { get; set; }

        //userId of the buyer, the userId of the product owner comes with the product
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
