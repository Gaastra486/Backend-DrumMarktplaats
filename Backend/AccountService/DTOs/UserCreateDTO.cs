using System.ComponentModel.DataAnnotations;

namespace AccountService.Microservice.DTOs
{
    public class UserCreateDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Postalcode { get; set; }
    }
}
