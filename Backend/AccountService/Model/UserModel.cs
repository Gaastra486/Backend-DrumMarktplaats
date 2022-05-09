using System.ComponentModel.DataAnnotations;

namespace AccountService.Models
{
    public class UserModel
    {
        [Required]
        public string Username { get; set; }


        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Postalcode { get; set; }  

        [Key]
        [Required]
        public int Id { get; set; }


    }
}
